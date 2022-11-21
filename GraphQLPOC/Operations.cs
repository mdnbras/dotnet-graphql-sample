using GraphQL;

namespace GraphQLPOC.GraphQLPOC {

    public class ConsultarCardGQL {
      /// <summary>
      /// ConsultarCardGQL.Request 
      /// <para>Required variables:<br/> { cardId=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = ConsultarCardDocument,
          OperationName = "consultarCard",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getConsultarCardGQL() {
        return Request();
      }
      
      public static string ConsultarCardDocument = @"
        query consultarCard($cardId: ID!) {
          card(id: $cardId) {
            id
            fields {
              value
              field {
                id
              }
            }
          }
        }
        ";
    }
    
}