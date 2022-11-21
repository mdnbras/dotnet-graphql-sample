// See https://aka.ms/new-console-template for more information

using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

namespace GraphQLPOC.GraphQLPOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExecutarRequest();
        }

        public static void ExecutarRequest()
        {
            var graphQLClient = new GraphQLHttpClient("https://api.pipefy.com/graphql", new NewtonsoftJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer xxxxxxxxxxx");
            
            var consultarCardRequest = ConsultarCardGQL.getConsultarCardGQL();
            consultarCardRequest.Variables = new
            {
                cardId = "595828772"
            };

            var graphQLResponse = graphQLClient.SendQueryAsync<Types.Card>(consultarCardRequest);
            var cardID = graphQLResponse.Result.Data.id;
            Console.WriteLine("CardID: " + cardID);
        }
    }
}

