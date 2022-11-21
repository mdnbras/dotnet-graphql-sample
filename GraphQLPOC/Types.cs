using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GraphQL;

namespace GraphQLPOC.GraphQLPOC {
  public class Types {
    
    #region AdvancedSearch
    /// <summary>
    /// Advanced search's inputs
    /// </summary>
    public class AdvancedSearch {
      #region members
      /// <summary>
      /// Logical AND on all given filters
      /// </summary>
      public List<AdvancedSearch> AND { get; set; }
    
      /// <summary>
      /// Logical OR on all given filters
      /// </summary>
      public List<AdvancedSearch> OR { get; set; }
    
      /// <summary>
      /// The field slug
      /// </summary>
      public string field { get; set; }
    
      /// <summary>
      /// The search operator
      /// </summary>
      public AdvancedSearchOperators? @operator { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      public string value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
      /// <summary>
      /// Advanced search valid operators
      /// </summary>
    public enum AdvancedSearchOperators {
      /// <summary>
      /// Equals to
      /// </summary>
      equal,
      /// <summary>
      /// Greater than
      /// </summary>
      gt,
      /// <summary>
      /// Greater than or equal to
      /// </summary>
      gte,
      /// <summary>
      /// Less than
      /// </summary>
      lt,
      /// <summary>
      /// Less than or equal to
      /// </summary>
      lte
    }
    
    
    #region AppAttachment
    public class AppAttachment {
      #region members
      [JsonProperty("card_id")]
      public string card_id { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("suid")]
      public string suid { get; set; }
    
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region AppAttachmentConnection
    /// <summary>
    /// The connection type for AppAttachment.
    /// </summary>
    public class AppAttachmentConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<AppAttachmentEdge> edges { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region AppAttachmentEdge
    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class AppAttachmentEdge {
      #region members
      /// <summary>
      /// A cursor for use in pagination.
      /// </summary>
      [JsonProperty("cursor")]
      public string cursor { get; set; }
    
      /// <summary>
      /// The item at the end of the edge.
      /// </summary>
      [JsonProperty("node")]
      public AppAttachment node { get; set; }
      #endregion
    }
    #endregion
    
    #region AssigneeField
    /// <summary>
    /// The assignee field
    /// </summary>
    public class AssigneeField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Assignee field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public List<PublicUser> initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Information about the members
      /// </summary>
      [Obsolete("This argument will be removed in the next update")]
      [JsonProperty("members")]
      public List<PublicUser> members { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region Attachment
    /// <summary>
    /// Attachment from card
    /// </summary>
    public class Attachment {
      #region members
      [JsonProperty("createdAt")]
      public DateTime createdAt { get; set; }
    
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      [JsonProperty("field")]
      public MinimalField field { get; set; }
    
      [JsonProperty("path")]
      public string path { get; set; }
    
      [JsonProperty("phase")]
      public Phase phase { get; set; }
    
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region AttachmentField
    /// <summary>
    /// The attachment field
    /// </summary>
    public class AttachmentField : FieldType {
      #region members
      /// <summary>
      /// The attachment field custom validation
      /// </summary>
      [JsonProperty("customValidation")]
      public string customValidation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region AutoFillFieldCollection
    public class AutoFillFieldCollection {
      #region members
      [JsonProperty("fieldId")]
      public string fieldId { get; set; }
    
      [JsonProperty("value")]
      public List<string> value { get; set; }
      #endregion
    }
    #endregion
    
    #region AutoFillFieldString
    public class AutoFillFieldString {
      #region members
      [JsonProperty("fieldId")]
      public string fieldId { get; set; }
    
      [JsonProperty("value")]
      public string value { get; set; }
      #endregion
    }
    #endregion
    
    #region Billing
    /// <summary>
    /// Billing plans notices
    /// </summary>
    public class Billing {
      #region members
      [JsonProperty("billingNoticePeriod")]
      public bool billingNoticePeriod { get; set; }
    
      [JsonProperty("pastDueNoticeAlert")]
      public bool pastDueNoticeAlert { get; set; }
    
      [JsonProperty("upgradeOnlyFreePlan")]
      public bool upgradeOnlyFreePlan { get; set; }
      #endregion
    }
    #endregion
    
    #region Card
    /// <summary>
    /// List of card information
    /// </summary>
    public class Card : MinimalCardInterface {
      #region members
      /// <summary>
      /// The seconds since the card was created
      /// </summary>
      [JsonProperty("age")]
      public int? age { get; set; }
    
      /// <summary>
      /// Information about the assigned users
      /// </summary>
      [JsonProperty("assignees")]
      public List<User> assignees { get; set; }
    
      /// <summary>
      /// Information about the attached files
      /// </summary>
      [JsonProperty("attachments")]
      public List<Attachment> attachments { get; set; }
    
      /// <summary>
      /// The card total attachments
      /// </summary>
      [JsonProperty("attachments_count")]
      public int attachments_count { get; set; }
    
      /// <summary>
      /// Information about the card's assignees
      /// </summary>
      [JsonProperty("cardAssignees")]
      public List<CardAssignee> cardAssignees { get; set; }
    
      /// <summary>
      /// The card total checked items
      /// </summary>
      [JsonProperty("checklist_items_checked_count")]
      public int checklist_items_checked_count { get; set; }
    
      /// <summary>
      /// The card total checklist items
      /// </summary>
      [JsonProperty("checklist_items_count")]
      public int checklist_items_count { get; set; }
    
      /// <summary>
      /// Information about the child pipe connections
      /// </summary>
      [JsonProperty("child_relations")]
      public List<CardRelationship> child_relations { get; set; }
    
      /// <summary>
      /// Information about the card comments
      /// </summary>
      [JsonProperty("comments")]
      public List<Comment> comments { get; set; }
    
      /// <summary>
      /// The card total comments
      /// </summary>
      [JsonProperty("comments_count")]
      public int comments_count { get; set; }
    
      /// <summary>
      /// When the card was created
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// Information about the card creator
      /// </summary>
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      /// <summary>
      /// When the card was created
      /// </summary>
      [Obsolete("created_at has been replaced by createdAt")]
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Information about the card creator
      /// </summary>
      [Obsolete("created_by has been replaced by createdBy")]
      [JsonProperty("created_by")]
      public User created_by { get; set; }
    
      /// <summary>
      /// The email the card creator
      /// </summary>
      [JsonProperty("creatorEmail")]
      public string creatorEmail { get; set; }
    
      /// <summary>
      /// Information about the card lateness
      /// </summary>
      [JsonProperty("currentLateness")]
      public cardLateness currentLateness { get; set; }
    
      /// <summary>
      /// Information about the card current phase
      /// </summary>
      [JsonProperty("current_phase")]
      public Phase current_phase { get; set; }
    
      /// <summary>
      /// The seconds since the card entered current phase
      /// </summary>
      [JsonProperty("current_phase_age")]
      public int? current_phase_age { get; set; }
    
      /// <summary>
      /// Whether the card is done
      /// </summary>
      [JsonProperty("done")]
      public bool? done { get; set; }
    
      /// <summary>
      /// The card due date
      /// </summary>
      [JsonProperty("due_date")]
      public any due_date { get; set; }
    
      /// <summary>
      /// The card email address
      /// </summary>
      [JsonProperty("emailMessagingAddress")]
      public string emailMessagingAddress { get; set; }
    
      /// <summary>
      /// Information about the card expiration
      /// </summary>
      [JsonProperty("expiration")]
      public CardExpiration expiration { get; set; }
    
      /// <summary>
      /// Whether the card is expired
      /// </summary>
      [JsonProperty("expired")]
      public bool expired { get; set; }
    
      /// <summary>
      /// Information about the card fields
      /// </summary>
      [JsonProperty("fields")]
      public List<CardField> fields { get; set; }
    
      /// <summary>
      /// When the card was finished
      /// </summary>
      [JsonProperty("finished_at")]
      public any finished_at { get; set; }
    
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Information about any inbox email read status
      /// </summary>
      [JsonProperty("inboxEmailsRead")]
      public bool inboxEmailsRead { get; set; }
    
      /// <summary>
      /// Information about the card emails
      /// </summary>
      [JsonProperty("inbox_emails")]
      public List<InboxEmail> inbox_emails { get; set; }
    
      /// <summary>
      /// Information about the card labels
      /// </summary>
      [JsonProperty("labels")]
      public List<Label> labels { get; set; }
    
      /// <summary>
      /// Whether the card is late
      /// </summary>
      [JsonProperty("late")]
      public bool late { get; set; }
    
      /// <summary>
      /// Whether the card is overdue
      /// </summary>
      [JsonProperty("overdue")]
      public bool overdue { get; set; }
    
      /// <summary>
      /// Information about the parent pipe connections
      /// </summary>
      [JsonProperty("parent_relations")]
      public List<CardRelationship> parent_relations { get; set; }
    
      /// <summary>
      /// The card path
      /// </summary>
      [JsonProperty("path")]
      public string path { get; set; }
    
      /// <summary>
      /// Information about the phases the card went through
      /// </summary>
      [JsonProperty("phases_history")]
      public List<PhaseDetail> phases_history { get; set; }
    
      /// <summary>
      /// Information about the pipe
      /// </summary>
      [JsonProperty("pipe")]
      public Pipe pipe { get; set; }
    
      /// <summary>
      /// The card public form submitter email if exists
      /// </summary>
      [JsonProperty("public_form_submitter_email")]
      public string public_form_submitter_email { get; set; }
    
      /// <summary>
      /// Information about the card current Repo
      /// </summary>
      [Obsolete("repo is no longer valid for Card")]
      [JsonProperty("repo")]
      public RepoTypes repo { get; set; }
    
      /// <summary>
      /// When the card first entered the current phase
      /// </summary>
      [JsonProperty("started_current_phase_at")]
      public any started_current_phase_at { get; set; }
    
      /// <summary>
      /// Information about the card subtitles
      /// </summary>
      [JsonProperty("subtitles")]
      public List<CardField> subtitles { get; set; }
    
      /// <summary>
      /// The card Small Unique ID
      /// </summary>
      [JsonProperty("suid")]
      public string suid { get; set; }
    
      /// <summary>
      /// Information about the card summary layout
      /// </summary>
      [JsonProperty("summary")]
      public List<Summary> summary { get; set; }
    
      /// <summary>
      /// Information about the card attributes summary layout
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<Summary> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the card custom fields summary layout
      /// </summary>
      [JsonProperty("summary_fields")]
      public List<Summary> summary_fields { get; set; }
    
      /// <summary>
      /// The card title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// When the card was last updated
      /// </summary>
      [JsonProperty("updated_at")]
      public any updated_at { get; set; }
    
      /// <summary>
      /// The card URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The card Unique UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region CardAssignee
    /// <summary>
    /// Represents an user assigned to a card
    /// </summary>
    public class CardAssignee {
      #region members
      [JsonProperty("assignedAt")]
      public any assignedAt { get; set; }
    
      [JsonProperty("id")]
      public int id { get; set; }
      #endregion
    }
    #endregion
    
    #region CardConnection
    /// <summary>
    /// The connection type for Card.
    /// </summary>
    public class CardConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<CardEdge> edges { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region CardEdge
    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class CardEdge {
      #region members
      /// <summary>
      /// A cursor for use in pagination.
      /// </summary>
      [JsonProperty("cursor")]
      public string cursor { get; set; }
    
      /// <summary>
      /// The item at the end of the edge.
      /// </summary>
      [JsonProperty("node")]
      public Card node { get; set; }
      #endregion
    }
    #endregion
    
    #region CardExpiration
    /// <summary>
    /// Information on card expiration
    /// </summary>
    public class CardExpiration {
      #region members
      /// <summary>
      /// Date and time when card has expired
      /// </summary>
      [JsonProperty("expiredAt")]
      public any expiredAt { get; set; }
    
      /// <summary>
      /// Date and time when card should become expired
      /// </summary>
      [JsonProperty("shouldExpireAt")]
      public any shouldExpireAt { get; set; }
      #endregion
    }
    #endregion
    
    #region CardField
    /// <summary>
    /// List of the card's field values informations.
    /// </summary>
    public class CardField : MinimalCardFieldValueInterface, RepoItemFieldGQLInterface {
      #region members
      /// <summary>
      /// The value of an Attachment, Checklists, Connection or Label field, processed as an array type
      /// </summary>
      [JsonProperty("array_value")]
      public List<string> array_value { get; set; }
    
      /// <summary>
      /// Information about the users assigned to the card
      /// </summary>
      [JsonProperty("assignee_values")]
      public List<User> assignee_values { get; set; }
    
      /// <summary>
      /// Information about cards and records connected with the card
      /// </summary>
      [JsonProperty("connectedRepoItems")]
      public List<PublicRepoItemTypes> connectedRepoItems { get; set; }
    
      /// <summary>
      /// Repo item (Card or Record) representation
      /// </summary>
      [Obsolete("Please, use connectedRepoItems")]
      [JsonProperty("connected_repo_items")]
      public List<RepoItemTypes> connected_repo_items { get; set; }
    
      /// <summary>
      /// The value of a Date, DateTime or DueDate field, processed as a date type
      /// </summary>
      [JsonProperty("date_value")]
      public DateTime date_value { get; set; }
    
      /// <summary>
      /// The value of a DateTime or DueDate field, processed as a date and time type
      /// </summary>
      [JsonProperty("datetime_value")]
      public any datetime_value { get; set; }
    
      /// <summary>
      /// Information about the card field
      /// </summary>
      [JsonProperty("field")]
      public MinimalField field { get; set; }
    
      /// <summary>
      /// When the field was filled
      /// </summary>
      [JsonProperty("filled_at")]
      public any filled_at { get; set; }
    
      /// <summary>
      /// The field float value
      /// </summary>
      [JsonProperty("float_value")]
      public float? float_value { get; set; }
    
      /// <summary>
      /// The searcheable name
      /// </summary>
      [JsonProperty("indexName")]
      public string indexName { get; set; }
    
      /// <summary>
      /// Information about the card label
      /// </summary>
      [JsonProperty("label_values")]
      public List<FieldLabel> label_values { get; set; }
    
      /// <summary>
      /// The field name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The field value for show
      /// </summary>
      [JsonProperty("native_value")]
      public string native_value { get; set; }
    
      /// <summary>
      /// Information about the field's phase
      /// </summary>
      [JsonProperty("phase_field")]
      public PhaseField phase_field { get; set; }
    
      /// <summary>
      /// The field value prepared for report
      /// </summary>
      [JsonProperty("report_value")]
      public string report_value { get; set; }
    
      /// <summary>
      /// When the field was last updated
      /// </summary>
      [JsonProperty("updated_at")]
      public any updated_at { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      [JsonProperty("value")]
      public string value { get; set; }
      #endregion
    }
    #endregion
    
    #region CardForm
    /// <summary>
    /// translation missing: en.api.documentation.card_form.description
    /// </summary>
    public class CardForm : PublicRepoGQLInterface, RepoItemFormGQLInterface {
      #region members
      /// <summary>
      /// The creation button label
      /// </summary>
      [JsonProperty("createButtonLabel")]
      public string createButtonLabel { get; set; }
    
      /// <summary>
      /// The available fields in Pipefy
      /// </summary>
      [JsonProperty("formFields")]
      public List<RepoItemFieldsTypes> formFields { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region CardRelation
    /// <summary>
    /// Represents a relation's between two cards or a card and a table_record.
    /// </summary>
    public class CardRelation {
      #region members
      /// <summary>
      /// Represents the child card identifier.
      /// </summary>
      [JsonProperty("childId")]
      public string childId { get; set; }
    
      /// <summary>
      /// Represents the card relation identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the parent card identifier.
      /// </summary>
      [JsonProperty("parentId")]
      public string parentId { get; set; }
    
      /// <summary>
      /// Represents the source identifier.
      /// </summary>
      [JsonProperty("sourceId")]
      public string sourceId { get; set; }
    
      /// <summary>
      /// Represents if the connection is through a PipeRelation or a Connection Field.
      /// 
      /// The possible values are:
      /// 
      /// - PipeRelation
      /// - Field
      /// </summary>
      [JsonProperty("sourceType")]
      public string sourceType { get; set; }
      #endregion
    }
    #endregion
    
    #region CardRelationship
    /// <summary>
    /// List of the card relation's information.
    /// </summary>
    public class CardRelationship {
      #region members
      /// <summary>
      /// Lookup the connected cards by their identifier.
      /// </summary>
      [JsonProperty("cards")]
      public List<Card> cards { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the chosen name of the relation.
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Lookup the connected pipe by its identifier.
      /// </summary>
      [JsonProperty("pipe")]
      public Pipe pipe { get; set; }
    
      /// <summary>
      /// Lookup the connected Pipe or Table.
      /// </summary>
      [JsonProperty("repo")]
      public RepoTypes repo { get; set; }
    
      /// <summary>
      /// Represents if the connection is through a PipeRelation or a Connection Field.
      /// 
      /// The possible values are:
      /// 
      /// - PipeRelation
      /// - Field
      /// </summary>
      [JsonProperty("source_type")]
      public string source_type { get; set; }
      #endregion
    }
    #endregion
    
    #region CardSearch
    /// <summary>
    /// Cards search's inputs
    /// </summary>
    public class CardSearch {
      #region members
      /// <summary>
      /// The assignee ID
      /// </summary>
      public List<string> assignee_ids { get; set; }
    
      /// <summary>
      /// The cards ID to be ignored
      /// </summary>
      public List<string> ignore_ids { get; set; }
    
      /// <summary>
      /// 3VL indicating whether theres an uread thread or not in the card
      /// </summary>
      public bool? inbox_emails_read { get; set; }
    
      /// <summary>
      /// Shows or not done records
      /// </summary>
      public bool? include_done { get; set; }
    
      /// <summary>
      /// The label ID
      /// </summary>
      public List<string> label_ids { get; set; }
    
      /// <summary>
      /// The strategy for searching list of ids (label and/or assignees). If nothing is selected, it will use union
      /// </summary>
      public CardSearchStrategy? search_strategy { get; set; }
    
      /// <summary>
      /// The cards title
      /// </summary>
      public string title { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
      /// <summary>
      /// Whether will get the union of the factors, or the intersection
      /// </summary>
    public enum CardSearchStrategy {
      /// <summary>
      /// Will get all cards containing all labels and all assignees id
      /// </summary>
      intersection,
      /// <summary>
      /// Will get all cards containing, at least, one label and, at least, one assignee id
      /// </summary>
      union
    }
    
    
    #region CardsImportation
    /// <summary>
    /// Cards importer information
    /// </summary>
    public class CardsImportation : RepoItemsImportationGQLInterface {
      #region members
      /// <summary>
      /// The importation date of creation
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// The importation creator
      /// </summary>
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      /// <summary>
      /// The importation date of creation formatted
      /// </summary>
      [JsonProperty("dateFormatted")]
      public string dateFormatted { get; set; }
    
      /// <summary>
      /// The importation ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The amount of cards imported
      /// </summary>
      [JsonProperty("importedCards")]
      public int? importedCards { get; set; }
    
      /// <summary>
      /// The importation status
      /// </summary>
      [JsonProperty("status")]
      public string status { get; set; }
    
      /// <summary>
      /// The xlsx file URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region CardsImporterInput
    /// <summary>
    /// Autogenerated input type of CardsImporter
    /// </summary>
    public class CardsImporterInput {
      #region members
      /// <summary>
      /// The spreadsheet column with the card assignees email
      /// </summary>
      public string assigneesColumn { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The spreadsheet column with the card phase
      /// </summary>
      public string currentPhaseColumn { get; set; }
    
      /// <summary>
      /// The spreadsheet column with the card due date
      /// </summary>
      public string dueDateColumn { get; set; }
    
      /// <summary>
      /// Array with the field ID and its spreadsheet column with the value
      /// </summary>
      public List<FieldValuesColumnsInput> fieldValuesColumns { get; set; }
    
      /// <summary>
      /// The spreadsheet column with the card label ID
      /// </summary>
      public string labelsColumn { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonRequired]
      public string pipeId { get; set; }
    
      /// <summary>
      /// The xlsx file URL
      /// </summary>
      [JsonRequired]
      public string url { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CardsImporterPayload
    /// <summary>
    /// Autogenerated return type of CardsImporter
    /// </summary>
    public class CardsImporterPayload {
      #region members
      /// <summary>
      /// Returns information about the importation
      /// </summary>
      [JsonProperty("cardsImportation")]
      public CardsImportation cardsImportation { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
      #endregion
    }
    #endregion
    
    #region ChecklistHorizontalField
    /// <summary>
    /// The horizontal checklist field
    /// </summary>
    public class ChecklistHorizontalField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Horizontal checklist field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public List<string> initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// The horizontal checklist options
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region ChecklistVerticalField
    /// <summary>
    /// The vertical checklist field
    /// </summary>
    public class ChecklistVerticalField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Vertical checklist field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public List<string> initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// The vertical checklist options
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region ClonePipesInput
    /// <summary>
    /// Autogenerated input type of ClonePipes
    /// </summary>
    public class ClonePipesInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      public string organization_id { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonRequired]
      public List<string> pipe_template_ids { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region ClonePipesPayload
    /// <summary>
    /// Autogenerated return type of ClonePipes
    /// </summary>
    public class ClonePipesPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the pipe
      /// </summary>
      [JsonProperty("pipes")]
      public List<Pipe> pipes { get; set; }
      #endregion
    }
    #endregion
    
    #region CnpjField
    /// <summary>
    /// The CNPJ field
    /// </summary>
    public class CnpjField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// CNPJ field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
      /// <summary>
      /// Allowed colors on Pipefy
      /// </summary>
    public enum Colors {
      /// <summary>
      /// Blue color
      /// </summary>
      blue,
      /// <summary>
      /// Cyan color
      /// </summary>
      cyan,
      /// <summary>
      /// Gray color
      /// </summary>
      gray,
      /// <summary>
      /// Green color
      /// </summary>
      green,
      /// <summary>
      /// Indigo color
      /// </summary>
      indigo,
      /// <summary>
      /// Lime color
      /// </summary>
      lime,
      /// <summary>
      /// orange color
      /// </summary>
      orange,
      /// <summary>
      /// Pink color
      /// </summary>
      pink,
      /// <summary>
      /// Purple color
      /// </summary>
      purple,
      /// <summary>
      /// Red color
      /// </summary>
      red,
      /// <summary>
      /// Sky color
      /// </summary>
      sky,
      /// <summary>
      /// Yellow color
      /// </summary>
      yellow
    }
    
    
    #region Comment
    /// <summary>
    /// List of comment information.
    /// </summary>
    public class Comment {
      #region members
      /// <summary>
      /// Lookup the comment's creator by its identifier.
      /// </summary>
      [JsonProperty("author")]
      public User author { get; set; }
    
      /// <summary>
      /// Represents the comment's creator name.
      /// </summary>
      [JsonProperty("author_name")]
      public string author_name { get; set; }
    
      /// <summary>
      /// Represents the comment's creation date and time.
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Represents the comment's identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the comment text.
      /// </summary>
      [JsonProperty("text")]
      public string text { get; set; }
      #endregion
    }
    #endregion
    
    #region Condition
    /// <summary>
    /// The condition is criterias that can be set to trigger an automation.
    /// </summary>
    public class Condition {
      #region members
      /// <summary>
      /// The parameters used in the condition.
      /// </summary>
      [JsonProperty("expressions")]
      public List<ConditionExpression> expressions { get; set; }
    
      /// <summary>
      /// The condition expressions order, defining groups of "AND" and "OR".
      /// </summary>
      [JsonProperty("expressions_structure")]
      public List<List<string>> expressions_structure { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.condition.fields.id
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Information about the card or record used as a condition.
      /// </summary>
      [JsonProperty("related_cards")]
      public List<Card> related_cards { get; set; }
      #endregion
    }
    #endregion
    
    #region ConditionExpression
    /// <summary>
    /// The condition architecture.
    /// </summary>
    public class ConditionExpression {
      #region members
      /// <summary>
      /// The field ID used in the condition.
      /// </summary>
      [JsonProperty("field_address")]
      public string field_address { get; set; }
    
      /// <summary>
      /// The condition ID.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The condition operation.
      /// 
      /// Valid options:
      /// - equals
      /// - not_equals
      /// - present
      /// - blank
      /// - string_contains
      /// - string_not_contains
      /// - number_greater_than
      /// - number_less_than
      /// - date_is_today
      /// - date_is_yesterday
      /// - date_in_current_week
      /// - date_in_last_week
      /// - date_in_current_month
      /// - date_in_last_month
      /// - date_in_current_year
      /// - date_in_last_year
      /// - date_is
      /// - date_is_after
      /// - date_is_before
      /// </summary>
      [JsonProperty("operation")]
      public string operation { get; set; }
    
      /// <summary>
      /// The number used to arrange condition's expressions in groups of "AND" and "OR".
      /// </summary>
      [JsonProperty("structure_id")]
      public string structure_id { get; set; }
    
      /// <summary>
      /// The value selected to be compared in the condition.
      /// </summary>
      [JsonProperty("value")]
      public string value { get; set; }
      #endregion
    }
    #endregion
    
    #region ConditionExpressionInput
    /// <summary>
    /// Condition's expression inputs
    /// </summary>
    public class ConditionExpressionInput {
      #region members
      /// <summary>
      /// The condition field's ID
      /// </summary>
      public string field_address { get; set; }
    
      /// <summary>
      /// The condition ID
      /// </summary>
      public string id { get; set; }
    
      /// <summary>
      /// The condition operation
      /// 
      /// Valid options:
      /// - equals
      /// - not_equals
      /// - present
      /// - blank
      /// - string_contains
      /// - string_not_contains
      /// - number_greater_than
      /// - number_less_than
      /// - date_is_today
      /// - date_is_yesterday
      /// - date_in_current_week
      /// - date_in_last_week
      /// - date_in_current_month
      /// - date_in_last_month
      /// - date_in_current_year
      /// - date_in_last_year
      /// - date_is
      /// - date_is_after
      /// - date_is_before
      /// </summary>
      public string operation { get; set; }
    
      /// <summary>
      /// The structure ID
      /// </summary>
      public string structure_id { get; set; }
    
      /// <summary>
      /// The value or field ID to be compared
      /// </summary>
      public string value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
      /// <summary>
      /// The condition field actions
      /// </summary>
    public enum ConditionFieldActions {
      /// <summary>
      /// Hide the field
      /// </summary>
      hidden
    }
    
    
    #region ConditionInput
    /// <summary>
    /// Condition's inputs
    /// </summary>
    public class ConditionInput {
      #region members
      /// <summary>
      /// Array with the expression inputs
      /// </summary>
      public List<ConditionExpressionInput> expressions { get; set; }
    
      /// <summary>
      /// Array of arrays with the condition's order. Defining groups of "AND" and "OR"
      /// </summary>
      public List<List<string>> expressions_structure { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region ConditionalField
    /// <summary>
    /// List of fields which need of expecicly conditions.
    /// </summary>
    public class ConditionalField {
      #region members
      /// <summary>
      /// Fields wich must be hidden
      /// </summary>
      [JsonProperty("fieldsToHide")]
      public List<PhaseField> fieldsToHide { get; set; }
      #endregion
    }
    #endregion
    
    #region ConnectedTable
    /// <summary>
    /// List of table information
    /// </summary>
    public class ConnectedTable : Repo {
      #region members
      /// <summary>
      /// Allows anyone to create cards
      /// </summary>
      [JsonProperty("anyone_can_create_card")]
      public bool? anyone_can_create_card { get; set; }
    
      /// <summary>
      /// Information about the database table authorization
      /// </summary>
      [JsonProperty("authorization")]
      public TableAuthorization? authorization { get; set; }
    
      /// <summary>
      /// Color of pipe/database
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// IDs of all fields in a pipe that trigger conditionals
      /// </summary>
      [JsonProperty("conditionExpressionsFieldIds")]
      public List<int?> conditionExpressionsFieldIds { get; set; }
    
      /// <summary>
      /// The content displayed in the start form button
      /// </summary>
      [JsonProperty("create_record_button_label")]
      public string create_record_button_label { get; set; }
    
      /// <summary>
      /// The Repo description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// The database table ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Information about the Repo labels
      /// </summary>
      [JsonProperty("labels")]
      public List<Label> labels { get; set; }
    
      /// <summary>
      /// Information about the Repo members
      /// </summary>
      [JsonProperty("members")]
      public List<Member> members { get; set; }
    
      /// <summary>
      /// Information about the current user permission
      /// </summary>
      [JsonProperty("my_permissions")]
      public TablePermission my_permissions { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo noun for their registries
      /// </summary>
      [JsonProperty("noun")]
      public string noun { get; set; }
    
      /// <summary>
      /// The orderable fields. Valid options: title, status, created_at, updated_at, finished_at
      /// </summary>
      [JsonProperty("orderableFields")]
      public List<string> orderableFields { get; set; }
    
      /// <summary>
      /// The orderable field types
      /// </summary>
      [JsonProperty("orderableTypes")]
      public List<string> orderableTypes { get; set; }
    
      /// <summary>
      /// Information about the organization
      /// </summary>
      [JsonProperty("organization")]
      public Organization organization { get; set; }
    
      /// <summary>
      /// User permissions for this repo
      /// </summary>
      [JsonProperty("permissions")]
      public RepoPermissionsInternalGQLType permissions { get; set; }
    
      /// <summary>
      /// Whether the Repo is public
      /// </summary>
      [JsonProperty("public")]
      public bool? @public { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [JsonProperty("publicForm")]
      public PublicFormInternal publicForm { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm` instead.")]
      [JsonProperty("publicFormSettings")]
      public PublicFormSettings publicFormSettings { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form")]
      public bool? public_form { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form_active")]
      public bool? public_form_active { get; set; }
    
      /// <summary>
      /// The repo start form phase id
      /// </summary>
      [JsonProperty("startFormPhaseId")]
      public string startFormPhaseId { get; set; }
    
      /// <summary>
      /// Information about the database table statuses
      /// </summary>
      [JsonProperty("statuses")]
      public List<TableRecordStatus> statuses { get; set; }
    
      /// <summary>
      /// Information about the data selected to be shown in the summarized view
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<SummaryAttribute> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the Repo summary options
      /// </summary>
      [JsonProperty("summary_options")]
      public List<SummaryGroup> summary_options { get; set; }
    
      /// <summary>
      /// Information about the database table fields
      /// </summary>
      [JsonProperty("table_fields")]
      public List<TableField> table_fields { get; set; }
    
      /// <summary>
      /// Fetches a group of records based on arguments
      /// </summary>
      [JsonProperty("table_records")]
      public TableRecordConnection table_records { get; set; }
    
      /// <summary>
      /// The database table total records
      /// </summary>
      [JsonProperty("table_records_count")]
      public int? table_records_count { get; set; }
    
      /// <summary>
      /// Information about the field selected to be the record title
      /// </summary>
      [JsonProperty("title_field")]
      public TableField title_field { get; set; }
    
      /// <summary>
      /// The database table URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The total users
      /// </summary>
      [JsonProperty("users_count")]
      public int? users_count { get; set; }
    
      /// <summary>
      /// The database uuid
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region ConnectorField
    /// <summary>
    /// The connection field
    /// </summary>
    public class ConnectorField : FieldType {
      #region members
      /// <summary>
      /// Whether can connect with existing items
      /// </summary>
      [JsonProperty("canConnectExisting")]
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Whether is possible to connect with multiple items
      /// </summary>
      [JsonProperty("canConnectMultiples")]
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Whether is possible to create new connected items
      /// </summary>
      [JsonProperty("canCreateNewConnected")]
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Repo (Pipe or Table) representation
      /// </summary>
      [JsonProperty("connectedRepo")]
      public PublicRepoUnion connectedRepo { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Connection field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public List<PublicRepoItem> initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region CpfField
    /// <summary>
    /// The CPF field
    /// </summary>
    public class CpfField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// CPF field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateCardInput
    /// <summary>
    /// Autogenerated input type of CreateCard
    /// </summary>
    public class CreateCardInput {
      #region members
      /// <summary>
      /// The assignee IDs
      /// </summary>
      public List<string> assignee_ids { get; set; }
    
      /// <summary>
      /// The card attachments
      /// </summary>
      public List<string> attachments { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The card due date
      /// </summary>
      public any due_date { get; set; }
    
      /// <summary>
      /// Array of inputs to fill card's fields
      /// </summary>
      public List<FieldValueInput> fields_attributes { get; set; }
    
      /// <summary>
      /// The label ID
      /// </summary>
      public List<string> label_ids { get; set; }
    
      /// <summary>
      /// The parent-card ID
      /// </summary>
      public List<string> parent_ids { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      public string phase_id { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonRequired]
      public string pipe_id { get; set; }
    
      /// <summary>
      /// The card title
      /// </summary>
      public string title { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateCardPayload
    /// <summary>
    /// Autogenerated return type of CreateCard
    /// </summary>
    public class CreateCardPayload {
      #region members
      /// <summary>
      /// Returns information about the card
      /// </summary>
      [JsonProperty("card")]
      public Card card { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateCardRelationInput
    /// <summary>
    /// Autogenerated input type of CreateCardRelation
    /// </summary>
    public class CreateCardRelationInput {
      #region members
      /// <summary>
      /// The child-card ID
      /// </summary>
      [JsonRequired]
      public string childId { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The parent-card ID
      /// </summary>
      [JsonRequired]
      public string parentId { get; set; }
    
      /// <summary>
      /// The connection ID or the field internal ID
      /// </summary>
      [JsonRequired]
      public string sourceId { get; set; }
    
      /// <summary>
      /// The connection sorce
      /// 
      /// Valid options:
      /// - PipeRelation
      /// - Field
      /// </summary>
      [JsonRequired]
      public string sourceType { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateCardRelationPayload
    /// <summary>
    /// Autogenerated return type of CreateCardRelation
    /// </summary>
    public class CreateCardRelationPayload {
      #region members
      /// <summary>
      /// Returns information about the cardRelation
      /// </summary>
      [JsonProperty("cardRelation")]
      public CardRelation cardRelation { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateCommentInput
    /// <summary>
    /// Autogenerated input type of CreateComment
    /// </summary>
    public class CreateCommentInput {
      #region members
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonRequired]
      public string card_id { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The comment text
      /// </summary>
      [JsonRequired]
      public string text { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateCommentPayload
    /// <summary>
    /// Autogenerated return type of CreateComment
    /// </summary>
    public class CreateCommentPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the comment
      /// </summary>
      [JsonProperty("comment")]
      public Comment comment { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateInboxEmailInput
    /// <summary>
    /// Autogenerated input type of CreateInboxEmail
    /// </summary>
    public class CreateInboxEmailInput {
      #region members
      /// <summary>
      /// The BCC (Blind Carbon Copy) email addresses
      /// </summary>
      public List<string> bcc { get; set; }
    
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonRequired]
      public string card_id { get; set; }
    
      /// <summary>
      /// The CC (Carbon Copy) email addresses
      /// </summary>
      public List<string> cc { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The email attachments
      /// </summary>
      public List<EmailAttachmentInput> emailAttachments { get; set; }
    
      /// <summary>
      /// The sender email address
      /// </summary>
      [JsonRequired]
      public string from { get; set; }
    
      /// <summary>
      /// The sender name
      /// </summary>
      public string fromName { get; set; }
    
      /// <summary>
      /// The sender name - deprecated
      /// </summary>
      public string from_name { get; set; }
    
      /// <summary>
      /// The email HTML
      /// </summary>
      public string html { get; set; }
    
      /// <summary>
      /// ARGUMENT IS DEPRECATED!
      /// </summary>
      public string main_to { get; set; }
    
      /// <summary>
      /// The Repo ID
      /// </summary>
      public string repo_id { get; set; }
    
      /// <summary>
      /// The Inbox Email state
      /// 
      /// Valid options:
      /// - 0: Pending
      /// - 1: Processing
      /// - 2: Processed
      /// - 3: Failed
      /// </summary>
      public string state { get; set; }
    
      /// <summary>
      /// The email subject
      /// </summary>
      [JsonRequired]
      public string subject { get; set; }
    
      /// <summary>
      /// The email text
      /// </summary>
      public string text { get; set; }
    
      /// <summary>
      /// The email destination addresses
      /// </summary>
      [JsonRequired]
      public List<string> to { get; set; }
    
      /// <summary>
      /// The email creator ID
      /// </summary>
      public string user_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateInboxEmailPayload
    /// <summary>
    /// Autogenerated return type of CreateInboxEmail
    /// </summary>
    public class CreateInboxEmailPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the inbox_email
      /// </summary>
      [JsonProperty("inbox_email")]
      public InboxEmail inbox_email { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateLabelInput
    /// <summary>
    /// Autogenerated input type of CreateLabel
    /// </summary>
    public class CreateLabelInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The label color (hexadecimal)
      /// </summary>
      [JsonRequired]
      public string color { get; set; }
    
      /// <summary>
      /// The label name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      public string pipe_id { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateLabelPayload
    /// <summary>
    /// Autogenerated return type of CreateLabel
    /// </summary>
    public class CreateLabelPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the label
      /// </summary>
      [JsonProperty("label")]
      public Label label { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateOrganizationInput
    /// <summary>
    /// Autogenerated input type of CreateOrganization
    /// </summary>
    public class CreateOrganizationInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The organization industry segment
      /// 
      /// Valid options:
      /// - construction
      /// - consulting
      /// - education
      /// - energy
      /// - financial_services
      /// - health
      /// - legal_services
      /// - manufacturing
      /// - marketing
      /// - non_profit_organization
      /// - public_sector
      /// - retail
      /// - tourism
      /// - technology
      /// - telecommunications
      /// - transportation
      /// - others
      /// </summary>
      [JsonRequired]
      public string industry { get; set; }
    
      /// <summary>
      /// The organization name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateOrganizationPayload
    /// <summary>
    /// Autogenerated return type of CreateOrganization
    /// </summary>
    public class CreateOrganizationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the organization
      /// </summary>
      [JsonProperty("organization")]
      public Organization organization { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateOrganizationWebhookInput
    /// <summary>
    /// Autogenerated input type of CreateOrganizationWebhook
    /// </summary>
    public class CreateOrganizationWebhookInput {
      #region members
      /// <summary>
      /// The webhook trigger(s)
      /// 
      /// Valid options:
      /// - user.invitation_sent
      /// - user.invitation_acceptance
      /// - user.removal_from_org
      /// - user.role_set
      /// </summary>
      [JsonRequired]
      public List<string> actions { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The webhook's notification email
      /// </summary>
      public string email { get; set; }
    
      /// <summary>
      /// The webhook's custom headers
      /// </summary>
      public any headers { get; set; }
    
      /// <summary>
      /// The webhook's name
      /// </summary>
      public string name { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      [JsonRequired]
      public string organization_id { get; set; }
    
      /// <summary>
      /// The webhook's notification URL
      /// </summary>
      public string url { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateOrganizationWebhookPayload
    /// <summary>
    /// Autogenerated return type of CreateOrganizationWebhook
    /// </summary>
    public class CreateOrganizationWebhookPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the webhook
      /// </summary>
      [JsonProperty("webhook")]
      public Webhook webhook { get; set; }
      #endregion
    }
    #endregion
    
    #region CreatePhaseFieldInput
    /// <summary>
    /// Autogenerated input type of CreatePhaseField
    /// </summary>
    public class CreatePhaseFieldInput {
      #region members
      /// <summary>
      /// Connection Field: Whether all children must be done to finish the parent
      /// </summary>
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Connection Field: Whether all children must be done to move the parent
      /// </summary>
      public bool? allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Connection Field: Whether can connect with existing items
      /// </summary>
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to connect with multiple items
      /// </summary>
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to create new connected items
      /// </summary>
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Connection Field: Whether a child must exist to finish the parent
      /// </summary>
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Connection Field: The Repo ID
      /// </summary>
      public string connectedRepoId { get; set; }
    
      /// <summary>
      /// The regex used to validate the field's value
      /// </summary>
      public string custom_validation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// Whether the field is editable
      /// </summary>
      public bool? editable { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      public string help { get; set; }
    
      /// <summary>
      /// The field index
      /// </summary>
      public float? index { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonRequired]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      public bool? minimal_view { get; set; }
    
      /// <summary>
      /// The field options
      /// </summary>
      public List<string> options { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      [JsonRequired]
      public string phase_id { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      public bool? required { get; set; }
    
      /// <summary>
      /// Whether the field is sync with the fixed field
      /// </summary>
      public bool? sync_with_card { get; set; }
    
      /// <summary>
      /// The field type
      /// 
      /// Valid options:
      /// - assignee_select
      /// - attachment
      /// - checklist_horizontal
      /// - checklist_vertical
      /// - cnpj
      /// - connector
      /// - cpf
      /// - currency
      /// - date
      /// - datetime
      /// - due_date
      /// - email
      /// - id
      /// - label_select
      /// - long_text
      /// - number
      /// - phone
      /// - radio_horizontal
      /// - radio_vertical
      /// - select
      /// - short_text
      /// - statement
      /// - time
      /// </summary>
      [JsonRequired]
      public string type { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreatePhaseFieldPayload
    /// <summary>
    /// Autogenerated return type of CreatePhaseField
    /// </summary>
    public class CreatePhaseFieldPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the phase field
      /// </summary>
      [JsonProperty("phase_field")]
      public PhaseField phase_field { get; set; }
      #endregion
    }
    #endregion
    
    #region CreatePhaseInput
    /// <summary>
    /// Autogenerated input type of CreatePhase
    /// </summary>
    public class CreatePhaseInput {
      #region members
      /// <summary>
      /// Whether cards can be created directly in the phase
      /// </summary>
      public bool? can_receive_card_directly_from_draft { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The phase description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// Whether it's a final phase
      /// </summary>
      public bool? done { get; set; }
    
      /// <summary>
      /// The index where phase will be created
      /// </summary>
      public float? index { get; set; }
    
      /// <summary>
      /// The phase's SLA in seconds
      /// </summary>
      public int? lateness_time { get; set; }
    
      /// <summary>
      /// The phase name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// ARGUMENT IS DEPRECATED!
      /// </summary>
      public bool? only_admin_can_move_to_previous { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonRequired]
      public string pipe_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreatePhasePayload
    /// <summary>
    /// Autogenerated return type of CreatePhase
    /// </summary>
    public class CreatePhasePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the phase
      /// </summary>
      [JsonProperty("phase")]
      public Phase phase { get; set; }
      #endregion
    }
    #endregion
    
    #region CreatePipeInput
    /// <summary>
    /// Autogenerated input type of CreatePipe
    /// </summary>
    public class CreatePipeInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Color of pipe
      /// </summary>
      public Colors? color { get; set; }
    
      /// <summary>
      /// The pipe icon
      /// 
      /// Valid options:
      /// - airplane
      /// - at
      /// - axe
      /// - badge
      /// - bag
      /// - boat
      /// - briefing
      /// - bug
      /// - bullhorn
      /// - calendar
      /// - cart
      /// - cat
      /// - chart-zoom
      /// - chart2
      /// - chat
      /// - check
      /// - checklist
      /// - compass
      /// - contract
      /// - dog
      /// - eiffel
      /// - emo
      /// - finish-flag
      /// - flame
      /// - frame
      /// - frog
      /// - game
      /// - github
      /// - globe
      /// - growth
      /// - hr-process
      /// - hr-requests
      /// - ice
      /// - juice
      /// - lamp
      /// - lemonade
      /// - liberty
      /// - like
      /// - mac
      /// - magic
      /// - map
      /// - message
      /// - mkt-requests
      /// - money
      /// - onboarding
      /// - pacman
      /// - pacman1
      /// - payable
      /// - phone
      /// - pipefy
      /// - pizza
      /// - planet
      /// - plug
      /// - receivables
      /// - receive
      /// - recruitment-requests
      /// - reload
      /// - rocket
      /// - sales
      /// - skull
      /// - snow-flake
      /// - star
      /// - target
      /// - task
      /// - task-management
      /// - trophy
      /// - underwear
      /// </summary>
      public string icon { get; set; }
    
      /// <summary>
      /// Array of inputs to create pipe's labels
      /// </summary>
      public List<LabelInput> labels { get; set; }
    
      /// <summary>
      /// Array of inputs to invite members to the pipe
      /// </summary>
      public List<MemberInput> members { get; set; }
    
      /// <summary>
      /// The pipe name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      [JsonRequired]
      public string organization_id { get; set; }
    
      /// <summary>
      /// Array of inputs to create pipe's phases
      /// </summary>
      public List<PhaseInput> phases { get; set; }
    
      /// <summary>
      /// The pipe preferences
      /// </summary>
      public RepoPreferenceInput preferences { get; set; }
    
      /// <summary>
      /// Array of inputs to create pipe's start form fields
      /// </summary>
      public List<PhaseFieldInput> start_form_fields { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreatePipePayload
    /// <summary>
    /// Autogenerated return type of CreatePipe
    /// </summary>
    public class CreatePipePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the pipe
      /// </summary>
      [JsonProperty("pipe")]
      public Pipe pipe { get; set; }
      #endregion
    }
    #endregion
    
    #region CreatePipeRelationInput
    /// <summary>
    /// Autogenerated input type of CreatePipeRelation
    /// </summary>
    public class CreatePipeRelationInput {
      #region members
      /// <summary>
      /// Whether all children must be done to finish the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all children must be done to move the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether the relation has auto fill active
      /// </summary>
      [JsonRequired]
      public bool autoFillFieldEnabled { get; set; }
    
      /// <summary>
      /// Whether can connect with existing items
      /// </summary>
      [JsonRequired]
      public bool canConnectExistingItems { get; set; }
    
      /// <summary>
      /// Whether is possible to connect with multiple items
      /// </summary>
      [JsonRequired]
      public bool canConnectMultipleItems { get; set; }
    
      /// <summary>
      /// Whether is possible to create new connected items
      /// </summary>
      [JsonRequired]
      public bool canCreateNewItems { get; set; }
    
      /// <summary>
      /// The child Repo ID
      /// </summary>
      [JsonRequired]
      public string childId { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Whether a child must exist to move the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToMoveParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The relation name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// Array of field input to be used in the auto fill
      /// </summary>
      public List<FieldMapInput> ownFieldMaps { get; set; }
    
      /// <summary>
      /// The parent Repo ID
      /// </summary>
      [JsonRequired]
      public string parentId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreatePipeRelationPayload
    /// <summary>
    /// Autogenerated return type of CreatePipeRelation
    /// </summary>
    public class CreatePipeRelationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the pipe relation
      /// </summary>
      [JsonProperty("pipeRelation")]
      public PipeRelation pipeRelation { get; set; }
      #endregion
    }
    #endregion
    
    #region CreatePresignedUrlForPipePdfTemplateInput
    /// <summary>
    /// Autogenerated input type of CreatePresignedUrlForPipePdfTemplate
    /// </summary>
    public class CreatePresignedUrlForPipePdfTemplateInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// File name
      /// </summary>
      [JsonRequired]
      public string fileName { get; set; }
    
      /// <summary>
      /// The organization id
      /// </summary>
      [JsonRequired]
      public string organizationId { get; set; }
    
      /// <summary>
      /// The pipe id
      /// </summary>
      [JsonRequired]
      public string pipeId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreatePresignedUrlForPipePdfTemplatePayload
    /// <summary>
    /// Autogenerated return type of CreatePresignedUrlForPipePdfTemplate
    /// </summary>
    public class CreatePresignedUrlForPipePdfTemplatePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The presigned url
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region CreatePresignedUrlInput
    /// <summary>
    /// Autogenerated input type of CreatePresignedUrl
    /// </summary>
    public class CreatePresignedUrlInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// File media type
      /// </summary>
      public string contentType { get; set; }
    
      /// <summary>
      /// File name
      /// </summary>
      [JsonRequired]
      public string fileName { get; set; }
    
      /// <summary>
      /// The organization id
      /// </summary>
      [JsonRequired]
      public string organizationId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreatePresignedUrlPayload
    /// <summary>
    /// Autogenerated return type of CreatePresignedUrl
    /// </summary>
    public class CreatePresignedUrlPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The download url
      /// </summary>
      [JsonProperty("downloadUrl")]
      public string downloadUrl { get; set; }
    
      /// <summary>
      /// The presigned url
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateTableFieldInput
    /// <summary>
    /// Autogenerated input type of CreateTableField
    /// </summary>
    public class CreateTableFieldInput {
      #region members
      /// <summary>
      /// Connection Field: Whether all children must be done to finish the parent
      /// </summary>
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Connection Field: Whether can connect with existing items
      /// </summary>
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to connect with multiple items
      /// </summary>
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to create new connected items
      /// </summary>
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Connection Field: Whether a child must exist to finish the parent
      /// </summary>
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Connection Field: The Repo ID
      /// </summary>
      public string connectedRepoId { get; set; }
    
      /// <summary>
      /// The regex used to validate the field's value
      /// </summary>
      public string custom_validation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      public string help { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonRequired]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      public bool? minimal_view { get; set; }
    
      /// <summary>
      /// The field options
      /// </summary>
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      public bool? required { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string table_id { get; set; }
    
      /// <summary>
      /// The field type
      /// 
      /// Valid options:
      /// - assignee_select
      /// - attachment
      /// - checklist_horizontal
      /// - checklist_vertical
      /// - cnpj
      /// - connector
      /// - cpf
      /// - currency
      /// - date
      /// - datetime
      /// - due_date
      /// - email
      /// - id
      /// - label_select
      /// - long_text
      /// - number
      /// - phone
      /// - radio_horizontal
      /// - radio_vertical
      /// - select
      /// - short_text
      /// - statement
      /// - time
      /// </summary>
      [JsonRequired]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      public bool? unique { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateTableFieldPayload
    /// <summary>
    /// Autogenerated return type of CreateTableField
    /// </summary>
    public class CreateTableFieldPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the table fields
      /// </summary>
      [JsonProperty("table_field")]
      public TableField table_field { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateTableInput
    /// <summary>
    /// Autogenerated input type of CreateTable
    /// </summary>
    public class CreateTableInput {
      #region members
      /// <summary>
      /// The table authorization
      /// 
      /// Valid options:
      /// - read
      /// - write
      /// </summary>
      public TableAuthorization? authorization { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Color of database
      /// </summary>
      public Colors? color { get; set; }
    
      /// <summary>
      /// The table description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// The pipe icon
      /// 
      /// Valid options:
      /// - airplane
      /// - at
      /// - axe
      /// - badge
      /// - bag
      /// - boat
      /// - briefing
      /// - bug
      /// - bullhorn
      /// - calendar
      /// - cart
      /// - cat
      /// - chart-zoom
      /// - chart2
      /// - chat
      /// - check
      /// - checklist
      /// - compass
      /// - contract
      /// - dog
      /// - eiffel
      /// - emo
      /// - finish-flag
      /// - flame
      /// - frame
      /// - frog
      /// - game
      /// - github
      /// - globe
      /// - growth
      /// - hr-process
      /// - hr-requests
      /// - ice
      /// - juice
      /// - lamp
      /// - lemonade
      /// - liberty
      /// - like
      /// - mac
      /// - magic
      /// - map
      /// - message
      /// - mkt-requests
      /// - money
      /// - onboarding
      /// - pacman
      /// - pacman1
      /// - payable
      /// - phone
      /// - pipefy
      /// - pizza
      /// - planet
      /// - plug
      /// - receivables
      /// - receive
      /// - recruitment-requests
      /// - reload
      /// - rocket
      /// - sales
      /// - skull
      /// - snow-flake
      /// - star
      /// - target
      /// - task
      /// - task-management
      /// - trophy
      /// - underwear
      /// </summary>
      public string icon { get; set; }
    
      /// <summary>
      /// Array of inputs to create table's labels
      /// </summary>
      public List<LabelInput> labels { get; set; }
    
      /// <summary>
      /// Array of inputs to invite members to the table
      /// </summary>
      public List<MemberInput> members { get; set; }
    
      /// <summary>
      /// The table name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      [JsonRequired]
      public string organization_id { get; set; }
    
      /// <summary>
      /// Whether the table is public
      /// </summary>
      public bool? @public { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateTablePayload
    /// <summary>
    /// Autogenerated return type of CreateTable
    /// </summary>
    public class CreateTablePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the table
      /// </summary>
      [JsonProperty("table")]
      public Table table { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateTableRecordInRestrictedTableInput
    /// <summary>
    /// Autogenerated input type of CreateTableRecordInRestrictedTable
    /// </summary>
    public class CreateTableRecordInRestrictedTableInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Array of inputs to fill record's fields
      /// </summary>
      public List<FieldValueInput> fieldsAttributes { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string tableId { get; set; }
    
      /// <summary>
      /// The connection field ID
      /// </summary>
      public ReferenceConnectorFieldInput throughConnectors { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateTableRecordInRestrictedTablePayload
    /// <summary>
    /// Autogenerated return type of CreateTableRecordInRestrictedTable
    /// </summary>
    public class CreateTableRecordInRestrictedTablePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the record
      /// </summary>
      [JsonProperty("tableRecord")]
      public PublicTableRecord tableRecord { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateTableRecordInput
    /// <summary>
    /// Autogenerated input type of CreateTableRecord
    /// </summary>
    public class CreateTableRecordInput {
      #region members
      /// <summary>
      /// The assignee IDs
      /// </summary>
      public List<string> assignee_ids { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The record due date
      /// </summary>
      public any due_date { get; set; }
    
      /// <summary>
      /// Array of inputs to fill record's fields
      /// </summary>
      public List<FieldValueInput> fields_attributes { get; set; }
    
      /// <summary>
      /// The label ID
      /// </summary>
      public List<string> label_ids { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string table_id { get; set; }
    
      /// <summary>
      /// The record title
      /// </summary>
      public string title { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateTableRecordPayload
    /// <summary>
    /// Autogenerated return type of CreateTableRecord
    /// </summary>
    public class CreateTableRecordPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the record
      /// </summary>
      [JsonProperty("table_record")]
      public TableRecord table_record { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateTableRelationInput
    /// <summary>
    /// Autogenerated input type of CreateTableRelation
    /// </summary>
    public class CreateTableRelationInput {
      #region members
      /// <summary>
      /// Whether all children must be done to finish the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all children must be done to move the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether can connect with existing items
      /// </summary>
      [JsonRequired]
      public bool canConnectExistingItems { get; set; }
    
      /// <summary>
      /// Whether is possible to connect with multiple items
      /// </summary>
      [JsonRequired]
      public bool canConnectMultipleItems { get; set; }
    
      /// <summary>
      /// Whether is possible to create new connected items
      /// </summary>
      [JsonRequired]
      public bool canCreateNewItems { get; set; }
    
      /// <summary>
      /// The child Repo ID
      /// </summary>
      [JsonRequired]
      public string childId { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Whether a child must exist to move the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToMoveParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The relation name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// The parent Repo ID
      /// </summary>
      [JsonRequired]
      public string parentId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateTableRelationPayload
    /// <summary>
    /// Autogenerated return type of CreateTableRelation
    /// </summary>
    public class CreateTableRelationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the table relation
      /// </summary>
      [JsonProperty("tableRelation")]
      public TableRelation tableRelation { get; set; }
      #endregion
    }
    #endregion
    
    #region CreateWebhookInput
    /// <summary>
    /// Autogenerated input type of CreateWebhook
    /// </summary>
    public class CreateWebhookInput {
      #region members
      /// <summary>
      /// The webhook trigger(s)
      /// 
      /// Valid options:
      /// - card.create
      /// - card.done
      /// - card.expired
      /// - card.late
      /// - card.move
      /// - card.overdue
      /// - card.field_update
      /// - card.delete
      /// </summary>
      [JsonRequired]
      public List<string> actions { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The webhook's notification email
      /// </summary>
      public string email { get; set; }
    
      /// <summary>
      /// The webhook's custom headers
      /// </summary>
      public any headers { get; set; }
    
      /// <summary>
      /// The webhook's name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// The Pipe ID or SUID
      /// </summary>
      public string pipe_id { get; set; }
    
      /// <summary>
      /// The Table ID or SUID
      /// </summary>
      public string table_id { get; set; }
    
      /// <summary>
      /// The webhook's notification URL
      /// </summary>
      [JsonRequired]
      public string url { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateWebhookPayload
    /// <summary>
    /// Autogenerated return type of CreateWebhook
    /// </summary>
    public class CreateWebhookPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the webhook
      /// </summary>
      [JsonProperty("webhook")]
      public Webhook webhook { get; set; }
      #endregion
    }
    #endregion
    
    #region CurrencyField
    /// <summary>
    /// The currency field
    /// </summary>
    public class CurrencyField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Currency field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public float? initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region DateField
    /// <summary>
    /// The date field
    /// </summary>
    public class DateField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Date field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public DateTime initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region DatetimeField
    /// <summary>
    /// The date time field
    /// </summary>
    public class DatetimeField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Date time field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public any initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteCardInput
    /// <summary>
    /// Autogenerated input type of DeleteCard
    /// </summary>
    public class DeleteCardInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteCardPayload
    /// <summary>
    /// Autogenerated return type of DeleteCard
    /// </summary>
    public class DeleteCardPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteCommentInput
    /// <summary>
    /// Autogenerated input type of DeleteComment
    /// </summary>
    public class DeleteCommentInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The comment ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteCommentPayload
    /// <summary>
    /// Autogenerated return type of DeleteComment
    /// </summary>
    public class DeleteCommentPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteFieldConditionInput
    /// <summary>
    /// Autogenerated input type of DeleteFieldCondition
    /// </summary>
    public class DeleteFieldConditionInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The field condition ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteFieldConditionPayload
    /// <summary>
    /// Autogenerated return type of DeleteFieldCondition
    /// </summary>
    public class DeleteFieldConditionPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteInboxEmailInput
    /// <summary>
    /// Autogenerated input type of DeleteInboxEmail
    /// </summary>
    public class DeleteInboxEmailInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The email ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteInboxEmailPayload
    /// <summary>
    /// Autogenerated return type of DeleteInboxEmail
    /// </summary>
    public class DeleteInboxEmailPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteLabelInput
    /// <summary>
    /// Autogenerated input type of DeleteLabel
    /// </summary>
    public class DeleteLabelInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The label ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteLabelPayload
    /// <summary>
    /// Autogenerated return type of DeleteLabel
    /// </summary>
    public class DeleteLabelPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteOrganizationInput
    /// <summary>
    /// Autogenerated input type of DeleteOrganization
    /// </summary>
    public class DeleteOrganizationInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteOrganizationPayload
    /// <summary>
    /// Autogenerated return type of DeleteOrganization
    /// </summary>
    public class DeleteOrganizationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteOrganizationWebhookGqlMutationInput
    /// <summary>
    /// Autogenerated input type of DeleteOrganizationWebhookGQLMutation
    /// </summary>
    public class DeleteOrganizationWebhookGqlMutationInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The webhook ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteOrganizationWebhookGQLMutationPayload
    /// <summary>
    /// Autogenerated return type of DeleteOrganizationWebhookGQLMutation
    /// </summary>
    public class DeleteOrganizationWebhookGQLMutationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeletePhaseFieldInput
    /// <summary>
    /// Autogenerated input type of DeletePhaseField
    /// </summary>
    public class DeletePhaseFieldInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The UUID of the pipe the field is in
      /// </summary>
      public string pipeUuid { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeletePhaseFieldPayload
    /// <summary>
    /// Autogenerated return type of DeletePhaseField
    /// </summary>
    public class DeletePhaseFieldPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeletePhaseInput
    /// <summary>
    /// Autogenerated input type of DeletePhase
    /// </summary>
    public class DeletePhaseInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeletePhasePayload
    /// <summary>
    /// Autogenerated return type of DeletePhase
    /// </summary>
    public class DeletePhasePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeletePipeInput
    /// <summary>
    /// Autogenerated input type of DeletePipe
    /// </summary>
    public class DeletePipeInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeletePipePayload
    /// <summary>
    /// Autogenerated return type of DeletePipe
    /// </summary>
    public class DeletePipePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeletePipeRelationInput
    /// <summary>
    /// Autogenerated input type of DeletePipeRelation
    /// </summary>
    public class DeletePipeRelationInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeletePipeRelationPayload
    /// <summary>
    /// Autogenerated return type of DeletePipeRelation
    /// </summary>
    public class DeletePipeRelationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteTableFieldInput
    /// <summary>
    /// Autogenerated input type of DeleteTableField
    /// </summary>
    public class DeleteTableFieldInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteTableFieldPayload
    /// <summary>
    /// Autogenerated return type of DeleteTableField
    /// </summary>
    public class DeleteTableFieldPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteTableInput
    /// <summary>
    /// Autogenerated input type of DeleteTable
    /// </summary>
    public class DeleteTableInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteTablePayload
    /// <summary>
    /// Autogenerated return type of DeleteTable
    /// </summary>
    public class DeleteTablePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteTableRecordInput
    /// <summary>
    /// Autogenerated input type of DeleteTableRecord
    /// </summary>
    public class DeleteTableRecordInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The record ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteTableRecordPayload
    /// <summary>
    /// Autogenerated return type of DeleteTableRecord
    /// </summary>
    public class DeleteTableRecordPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteTableRelationInput
    /// <summary>
    /// Autogenerated input type of DeleteTableRelation
    /// </summary>
    public class DeleteTableRelationInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteTableRelationPayload
    /// <summary>
    /// Autogenerated return type of DeleteTableRelation
    /// </summary>
    public class DeleteTableRelationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DeleteWebhookInput
    /// <summary>
    /// Autogenerated input type of DeleteWebhook
    /// </summary>
    public class DeleteWebhookInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The webhook's ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region DeleteWebhookPayload
    /// <summary>
    /// Autogenerated return type of DeleteWebhook
    /// </summary>
    public class DeleteWebhookPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region DueDateField
    /// <summary>
    /// The due date field
    /// </summary>
    public class DueDateField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Due date field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public any initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region DynamicContentField
    /// <summary>
    /// The dynamic content field
    /// </summary>
    public class DynamicContentField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region EmailAttachment
    /// <summary>
    /// List of Email Attachments.
    /// </summary>
    public class EmailAttachment {
      #region members
      /// <summary>
      /// Represents the file url.
      /// </summary>
      [JsonProperty("fileUrl")]
      public string fileUrl { get; set; }
    
      /// <summary>
      /// Represents the name of the file of the attachment.
      /// </summary>
      [JsonProperty("filename")]
      public string filename { get; set; }
    
      /// <summary>
      /// Represents each email attachment identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the full path of the file url.
      /// </summary>
      [JsonProperty("public_url")]
      public string public_url { get; set; }
      #endregion
    }
    #endregion
    
    #region EmailAttachmentInput
    /// <summary>
    /// Email attachment's inputs
    /// </summary>
    public class EmailAttachmentInput {
      #region members
      /// <summary>
      /// The file name
      /// </summary>
      public string fileName { get; set; }
    
      /// <summary>
      /// The file's URL
      /// </summary>
      [JsonRequired]
      public string fileUrl { get; set; }
    
      /// <summary>
      /// The file's public URL
      /// </summary>
      public string publicUrl { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region EmailField
    /// <summary>
    /// The email field
    /// </summary>
    public class EmailField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Email field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region EmailToInviteInput
    /// <summary>
    /// Email invite's inputs
    /// </summary>
    public class EmailToInviteInput {
      #region members
      /// <summary>
      /// The email address
      /// </summary>
      [JsonRequired]
      public string email { get; set; }
    
      /// <summary>
      /// The role name
      /// 
      /// Valid Options:
      /// 1. Organization
      /// - admin
      /// - normal
      /// - company_guest
      /// - external_guest
      /// 2. Pipe
      /// - admin
      /// - member
      /// - creator
      /// - my_cards_only
      /// 3. Table
      /// - admin
      /// - member
      /// </summary>
      [JsonRequired]
      public string role_name { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region Errors
    /// <summary>
    /// translation missing: en.api.documentation.errors.query
    /// </summary>
    public class Errors {
      #region members
      [JsonProperty("index")]
      public int? index { get; set; }
    
      [JsonProperty("message")]
      public string message { get; set; }
      #endregion
    }
    #endregion
    
    #region ExportPipeReportInput
    /// <summary>
    /// Autogenerated input type of ExportPipeReport
    /// </summary>
    public class ExportPipeReportInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The fields to be added as columns in the exported XLSX file
      /// </summary>
      public List<string> columns { get; set; }
    
      /// <summary>
      /// The filter to be applied in this exportation
      /// </summary>
      public ReportCardsFilter filter { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonRequired]
      public string pipeId { get; set; }
    
      /// <summary>
      /// The report ID
      /// </summary>
      [JsonRequired]
      public string pipeReportId { get; set; }
    
      /// <summary>
      /// The sort direction of the results (as they will appear in the XSLX file)
      /// </summary>
      public ReportSortDirectionInput sortBy { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region ExportPipeReportPayload
    /// <summary>
    /// Autogenerated return type of ExportPipeReport
    /// </summary>
    public class ExportPipeReportPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information on the report export
      /// </summary>
      [JsonProperty("pipeReportExport")]
      public PipeReportExport pipeReportExport { get; set; }
      #endregion
    }
    #endregion
      /// <summary>
      /// Exportation work state
      /// </summary>
    public enum ExportationState {
      /// <summary>
      /// Work is finished
      /// </summary>
      done,
      /// <summary>
      /// Work failed
      /// </summary>
      failed,
      /// <summary>
      /// Work is under process
      /// </summary>
      processing
    }
    
    
    #region FieldCondition
    /// <summary>
    /// translation missing: en.api.documentation.field_condition.description
    /// </summary>
    public class FieldCondition {
      #region members
      /// <summary>
      /// translation missing: en.api.documentation.field_condition.actions
      /// </summary>
      [JsonProperty("actions")]
      public List<FieldConditionAction> actions { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition.condition
      /// </summary>
      [JsonProperty("condition")]
      public Condition condition { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition.id
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition.index
      /// </summary>
      [JsonProperty("isTrueFor")]
      public bool? isTrueFor { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition.name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition.phase
      /// </summary>
      [JsonProperty("phase")]
      public Phase phase { get; set; }
      #endregion
    }
    #endregion
    
    #region FieldConditionAction
    /// <summary>
    /// translation missing: en.api.documentation.field_condition_action.description
    /// </summary>
    public class FieldConditionAction {
      #region members
      /// <summary>
      /// translation missing: en.api.documentation.field_condition_action.action
      /// </summary>
      [JsonProperty("actionId")]
      public string actionId { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition_action.id
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition_action.field
      /// </summary>
      [JsonProperty("phase")]
      public Phase phase { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition_action.field
      /// </summary>
      [JsonProperty("phaseField")]
      public PhaseField phaseField { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.field_condition_action.field
      /// </summary>
      [Obsolete("phaseFieldId is deprecated. Use phaseField instead.")]
      [JsonProperty("phaseFieldId")]
      public string phaseFieldId { get; set; }
    
      /// <summary>
      /// When condition evaluator
      /// </summary>
      [JsonProperty("whenEvaluator")]
      public bool? whenEvaluator { get; set; }
      #endregion
    }
    #endregion
    
    #region FieldConditionActionInput
    /// <summary>
    /// Field condition's inputs
    /// </summary>
    public class FieldConditionActionInput {
      #region members
      /// <summary>
      /// The condition action
      /// 
      /// Valid options:
      /// - hide
      /// - show
      /// </summary>
      public string actionId { get; set; }
    
      /// <summary>
      /// The condition ID
      /// </summary>
      public string id { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      public string phaseFieldId { get; set; }
    
      /// <summary>
      /// The phase for bulk actions
      /// </summary>
      public string phaseId { get; set; }
    
      /// <summary>
      /// The validation of the conditional
      /// </summary>
      public bool? whenEvaluator { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region FieldLabel
    /// <summary>
    /// List of the label information.
    /// </summary>
    public class FieldLabel {
      #region members
      /// <summary>
      /// Represents the color used in the label using a hexadecimal string.
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// Represents the label identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the label name.
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region FieldMap
    /// <summary>
    /// The field map represents the field ID of the father-card and the related field ID of the child-card.
    /// </summary>
    public class FieldMap {
      #region members
      /// <summary>
      /// The field ID of the father-card.
      /// </summary>
      [JsonProperty("fieldId")]
      public string fieldId { get; set; }
    
      /// <summary>
      /// The field ID of the father-card.
      /// </summary>
      [Obsolete("field_id is deprecated, use fieldId instead")]
      [JsonProperty("field_id")]
      public string field_id { get; set; }
    
      /// <summary>
      /// How the value is going to be parsed:
      /// 
      /// Valid options:
      /// - fixed_value: uses a fix value for the field.
      /// - copy_from: copies the value of the father-card.
      /// </summary>
      [JsonProperty("inputMode")]
      public string inputMode { get; set; }
    
      /// <summary>
      /// The field ID of the child-card.
      /// </summary>
      [JsonProperty("value")]
      public string value { get; set; }
      #endregion
    }
    #endregion
    
    #region FieldMapInput
    /// <summary>
    /// Field map's inputs
    /// </summary>
    public class FieldMapInput {
      #region members
      /// <summary>
      /// The parent-card field ID
      /// </summary>
      [JsonRequired]
      public string fieldId { get; set; }
    
      /// <summary>
      /// The value input mode
      /// 
      /// Valid options:
      /// - fixed_value
      /// - copy_from
      /// </summary>
      [JsonRequired]
      public string inputMode { get; set; }
    
      /// <summary>
      /// The child-card field ID or the fixed value
      /// </summary>
      [JsonRequired]
      public string value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Field information
    /// </summary>
    public interface FieldType {
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    }
    
    #region FieldValueInput
    /// <summary>
    /// Field value's inputs
    /// </summary>
    public class FieldValueInput {
      #region members
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string field_id { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      public List<any> field_value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region FieldValuesColumnsInput
    /// <summary>
    /// Field's column inputs
    /// </summary>
    public class FieldValuesColumnsInput {
      #region members
      /// <summary>
      /// The spreadsheet column
      /// </summary>
      [JsonRequired]
      public string column { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string fieldId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region FilledField
    /// <summary>
    /// Filled field's inputs
    /// </summary>
    public class FilledField {
      #region members
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string fieldId { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      public List<any> fieldValue { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region FindCards
    /// <summary>
    /// Cards search's inputs
    /// </summary>
    public class FindCards {
      #region members
      /// <summary>
      /// The field id
      /// </summary>
      [JsonRequired]
      public string fieldId { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      [JsonRequired]
      public string fieldValue { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Generic field information
    /// </summary>
    public interface GenericField {
      /// <summary>
      /// Whether all child items must be done to finish the parent item
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToFinishParent")]
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether it's possible to connect existing items
      /// </summary>
      [JsonProperty("canConnectExisting")]
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Whether it's possible to connect multiple items
      /// </summary>
      [JsonProperty("canConnectMultiples")]
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Whether its possible to create new connected items
      /// </summary>
      [JsonProperty("canCreateNewConnected")]
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonProperty("childMustExistToFinishParent")]
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Repo (Pipe or Table) representation
      /// </summary>
      [JsonProperty("connectedRepo")]
      public PublicRepoUnion connectedRepo { get; set; }
    
      /// <summary>
      /// Repo (Pipe or Table) representation
      /// </summary>
      [Obsolete("connected_repo has been replaced by connectedRepo")]
      [JsonProperty("connected_repo")]
      public RepoTypes connected_repo { get; set; }
    
      /// <summary>
      /// The regex used to validate the field value
      /// </summary>
      [JsonProperty("custom_validation")]
      public string custom_validation { get; set; }
    
      /// <summary>
      /// Whether the field accepts multiple entries
      /// </summary>
      [JsonProperty("is_multiple")]
      public bool? is_multiple { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimal_view")]
      public bool? minimal_view { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("required")]
      public bool? required { get; set; }
    }
    
    #region HelpLink
    /// <summary>
    /// Shows improvement's help link information
    /// </summary>
    public class HelpLink {
      #region members
      /// <summary>
      /// Represents the link description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Represents the link icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// Represents the link identifier
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Whether the link opens in a new tab
      /// </summary>
      [JsonProperty("newTab")]
      public bool? newTab { get; set; }
    
      /// <summary>
      /// Represents the link title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// Represents the link url
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region Icon
    public class Icon {
      #region members
      [JsonProperty("color")]
      public string color { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region IdField
    /// <summary>
    /// The ID field
    /// </summary>
    public class IdField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field display value
      /// </summary>
      [JsonProperty("displayValue")]
      public string displayValue { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region Improvement
    /// <summary>
    /// List of improvements by pipe
    /// </summary>
    public class Improvement {
      #region members
      /// <summary>
      /// The improvement's app
      /// </summary>
      [JsonProperty("app")]
      public PlatformApp app { get; set; }
    
      /// <summary>
      /// The improvement's view state
      /// </summary>
      [JsonProperty("clicked")]
      public bool clicked { get; set; }
    
      /// <summary>
      /// The improvement's dismiss state
      /// </summary>
      [JsonProperty("dismissed")]
      public bool dismissed { get; set; }
    
      /// <summary>
      /// The improvement's view state
      /// </summary>
      [JsonProperty("enabled")]
      public bool enabled { get; set; }
    
      /// <summary>
      /// Represents each improvement's identifier
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The improvement's help link
      /// </summary>
      [JsonProperty("link")]
      public HelpLink link { get; set; }
    
      /// <summary>
      /// The improvement's dismiss state
      /// </summary>
      [JsonProperty("viewed")]
      public bool viewed { get; set; }
      #endregion
    }
    #endregion
    
    #region ImprovementSetting
    /// <summary>
    /// Show a pipe's improvement setting
    /// </summary>
    public class ImprovementSetting {
      #region members
      /// <summary>
      /// Represents improvement setting's description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Represents improvement setting's identifier
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// List all improvements of an improvement setting
      /// </summary>
      [JsonProperty("improvements")]
      public List<Improvement> improvements { get; set; }
    
      /// <summary>
      /// Represents the improvement setting's title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
      #endregion
    }
    #endregion
    
    #region InboxEmail
    /// <summary>
    /// List of the Inbox Email information.
    /// </summary>
    public class InboxEmail {
      #region members
      /// <summary>
      /// Lookup the email's attachments by its identifier.
      /// </summary>
      [JsonProperty("attachments")]
      public List<EmailAttachment> attachments { get; set; }
    
      /// <summary>
      /// Represents Inbox Email 'BCC' email addresses.
      /// </summary>
      [JsonProperty("bcc")]
      public List<string> bcc { get; set; }
    
      /// <summary>
      /// Represents Inbox Email body, with any eventual previous replies removed.
      /// </summary>
      [JsonProperty("body")]
      public string body { get; set; }
    
      /// <summary>
      /// Lookup the card, from which the Inbox Email was sent, by its identifier.
      /// </summary>
      [JsonProperty("card")]
      public Card card { get; set; }
    
      /// <summary>
      /// Represents Inbox Email 'CC' email addresses.
      /// </summary>
      [JsonProperty("cc")]
      public List<string> cc { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.inbox_email.fields.clean_body
      /// </summary>
      [Obsolete("Use the body attribute instead")]
      [JsonProperty("clean_body")]
      public string clean_body { get; set; }
    
      /// <summary>
      /// Represents Inbox Email's clean HTML, only filtering the invalid or malicious characters and tags.
      /// </summary>
      [JsonProperty("clean_html")]
      public string clean_html { get; set; }
    
      /// <summary>
      /// Represents Inbox Email's clean text, only filtering the invalid or malicious characters and tags.
      /// </summary>
      [JsonProperty("clean_text")]
      public string clean_text { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.inbox_email.fields.created_at
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Represents Inbox Email sender email address.
      /// </summary>
      [JsonProperty("from")]
      public string from { get; set; }
    
      /// <summary>
      /// Represents Inbox Email sender's name.
      /// </summary>
      [JsonProperty("fromName")]
      public string fromName { get; set; }
    
      /// <summary>
      /// Represents Inbox Email sender's name.
      /// </summary>
      [Obsolete("please, use fromName")]
      [JsonProperty("from_name")]
      public string from_name { get; set; }
    
      /// <summary>
      /// Represents each email's identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents Inbox Email's primary email addresses destination.
      /// </summary>
      [JsonProperty("main_to")]
      public string main_to { get; set; }
    
      /// <summary>
      /// Represents the Inbox Email answer message identifier.
      /// </summary>
      [JsonProperty("message_id")]
      public string message_id { get; set; }
    
      /// <summary>
      /// Lookup the pipe, from which the Inbox Email was sent, by its identifier.
      /// </summary>
      [JsonProperty("pipe")]
      public Pipe pipe { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.inbox_email.fields.raw_body
      /// </summary>
      [Obsolete("Use the body attribute instead")]
      [JsonProperty("raw_body")]
      public string raw_body { get; set; }
    
      /// <summary>
      /// Represents Inbox Email raw headers.
      /// </summary>
      [JsonProperty("raw_headers")]
      public string raw_headers { get; set; }
    
      /// <summary>
      /// Represents Inbox Email raw HTML format, only filtering invalid characters.
      /// </summary>
      [JsonProperty("raw_html")]
      public string raw_html { get; set; }
    
      /// <summary>
      /// translation missing: en.api.documentation.inbox_email.fields.raw_text
      /// </summary>
      [Obsolete("Use the clean text attribute instead")]
      [JsonProperty("raw_text")]
      public string raw_text { get; set; }
    
      /// <summary>
      /// Indicates if this email was sent using an automation
      /// </summary>
      [JsonProperty("sent_via_automation")]
      public bool? sent_via_automation { get; set; }
    
      /// <summary>
      /// Represents Inbox Email state, which can be:
      /// 
      /// * 0 - Pending
      /// * 1 - Processing
      /// * 2 - Processed
      /// * 3 - Failed
      /// </summary>
      [JsonProperty("state")]
      public string state { get; set; }
    
      /// <summary>
      /// Represents Inbox Email subject.
      /// </summary>
      [JsonProperty("subject")]
      public string subject { get; set; }
    
      /// <summary>
      /// Represents Inbox Email receiver email address.
      /// </summary>
      [JsonProperty("to")]
      public List<string> to { get; set; }
    
      [JsonProperty("type")]
      public InboxEmailType? type { get; set; }
    
      /// <summary>
      /// Represents last Inbox Email update date and time.
      /// </summary>
      [JsonProperty("updated_at")]
      public any updated_at { get; set; }
    
      /// <summary>
      /// Lookup the email's creator.
      /// </summary>
      [JsonProperty("user")]
      public User user { get; set; }
      #endregion
    }
    #endregion
      /// <summary>
      /// Possible inbox email types
      /// </summary>
    public enum InboxEmailType {
      /// <summary>
      /// Email received
      /// </summary>
      received,
      /// <summary>
      /// Email sent
      /// </summary>
      sent
    }
    
    
    #region InviteMembersInput
    /// <summary>
    /// Autogenerated input type of InviteMembers
    /// </summary>
    public class InviteMembersInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Emails to be invited
      /// </summary>
      [JsonRequired]
      public List<EmailToInviteInput> emails { get; set; }
    
      /// <summary>
      /// A message to be sent to the invitees
      /// </summary>
      public string message { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      public string organization_id { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      public string pipe_id { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region InviteMembersPayload
    /// <summary>
    /// Autogenerated return type of InviteMembers
    /// </summary>
    public class InviteMembersPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns possible errors in the mutation
      /// </summary>
      [JsonProperty("errors")]
      public List<Errors> errors { get; set; }
    
      /// <summary>
      /// Returns information about the new users
      /// </summary>
      [JsonProperty("users")]
      public List<User> users { get; set; }
      #endregion
    }
    #endregion
    
    #region Label
    /// <summary>
    /// List of the label information.
    /// </summary>
    public class Label {
      #region members
      /// <summary>
      /// Represents the color used in the label using a hexadecimal string.
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// Represents the label identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the label name.
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region LabelField
    /// <summary>
    /// The label field
    /// </summary>
    public class LabelField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Label field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public List<Label> initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Array with label information
      /// </summary>
      [JsonProperty("labels")]
      public List<Label> labels { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region LabelInput
    /// <summary>
    /// Label's inputs
    /// </summary>
    public class LabelInput {
      #region members
      /// <summary>
      /// The label color (hexadecimal)
      /// </summary>
      [JsonRequired]
      public string color { get; set; }
    
      /// <summary>
      /// The label name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region LongTextField
    /// <summary>
    /// The long text field
    /// </summary>
    public class LongTextField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Long text field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region Member
    /// <summary>
    /// Member information
    /// </summary>
    public class Member {
      #region members
      /// <summary>
      /// The user role name
      /// 
      /// Valid roles:
      /// 1. Organization:
      /// - admin: Team admin, can view/join all pipes and access/manage the team settings;
      /// - normal: Team member, can view and join all public pipes;
      /// - company_guest: Team guest, can only create cards in authorized forms. No access to pipes or databases. Can become a Member by creating a pipe or being added to one.
      /// - external_guest: External guest, can only create cards in authorized forms. No access to pipes or databases.
      /// 
      /// 2. Pipe:
      /// - admin: Pipe admin, can create and edit cards as well as manage the pipe settings;
      /// - member: Pipe member, can create new cards as well as access the existing ones to edit and move them across the pipe;
      /// - creator: Pipe start form only, has limited access to the pipe - can create cards;
      /// - my_cards_only: Pipe restricted view, can create new cards but is only allowed to view/edit cards created by or assigned to him;
      /// - read_and_comment: Pipe read only, can view the cards and add comments.
      /// 
      /// 3. Database Table:
      /// - admin: Table admin, can create an edit records, edit the table and its settings;
      /// - member: Table member, can view and create records (if authorized on the settings).
      /// </summary>
      [JsonProperty("role_name")]
      public string role_name { get; set; }
    
      /// <summary>
      /// The user information
      /// </summary>
      [JsonProperty("user")]
      public User user { get; set; }
      #endregion
    }
    #endregion
    
    #region MemberInput
    /// <summary>
    /// Member's inputs
    /// </summary>
    public class MemberInput {
      #region members
      /// <summary>
      /// The user role name
      /// 
      /// Valid roles:
      /// 1. Organization:
      /// - admin: Team admin, can view/join all pipes and access/manage the team settings;
      /// - normal: Team member, can view and join all public pipes;
      /// - company_guest: Team guest, can only create cards in authorized forms. No access to pipes or databases. Can become a Member by creating a pipe or being added to one.
      /// - external_guest: External guest, can only create cards in authorized forms. No access to pipes or databases.
      /// 
      /// 2. Pipe:
      /// - admin: Pipe admin, can create and edit cards as well as manage the pipe settings;
      /// - member: Pipe member, can create new cards as well as access the existing ones to edit and move them across the pipe;
      /// - creator: Pipe start form only, has limited access to the pipe - can create cards;
      /// - my_cards_only: Pipe restricted view, can create new cards but is only allowed to view/edit cards created by or assigned to him;
      /// - read_and_comment: Pipe read only, can view the cards and add comments.
      /// 
      /// 3. Database Table:
      /// - admin: Table admin, can create an edit records, edit the table and its settings;
      /// - member: Table member, can view and create records (if authorized on the settings).
      /// </summary>
      [JsonRequired]
      public string role_name { get; set; }
    
      /// <summary>
      /// The user ID
      /// </summary>
      [JsonRequired]
      public string user_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Card field value information
    /// </summary>
    public interface MinimalCardFieldValueInterface {
      /// <summary>
      /// The value of an Attachment, Checklists, Connection or Label field, processed as an array type
      /// </summary>
      [JsonProperty("array_value")]
      public List<string> array_value { get; set; }
    
      /// <summary>
      /// Information about the users assigned to the card
      /// </summary>
      [JsonProperty("assignee_values")]
      public List<User> assignee_values { get; set; }
    
      /// <summary>
      /// Information about cards and records connected with the card
      /// </summary>
      [JsonProperty("connectedRepoItems")]
      public List<PublicRepoItemTypes> connectedRepoItems { get; set; }
    
      /// <summary>
      /// The value of a Date, DateTime or DueDate field, processed as a date type
      /// </summary>
      [JsonProperty("date_value")]
      public DateTime date_value { get; set; }
    
      /// <summary>
      /// The value of a DateTime or DueDate field, processed as a date and time type
      /// </summary>
      [JsonProperty("datetime_value")]
      public any datetime_value { get; set; }
    
      /// <summary>
      /// Information about the card field
      /// </summary>
      [JsonProperty("field")]
      public MinimalField field { get; set; }
    
      /// <summary>
      /// The field float value
      /// </summary>
      [JsonProperty("float_value")]
      public float? float_value { get; set; }
    
      /// <summary>
      /// Information about the card label
      /// </summary>
      [JsonProperty("label_values")]
      public List<FieldLabel> label_values { get; set; }
    
      /// <summary>
      /// The field value for show
      /// </summary>
      [JsonProperty("native_value")]
      public string native_value { get; set; }
    
      /// <summary>
      /// The field value prepared for report
      /// </summary>
      [JsonProperty("report_value")]
      public string report_value { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      [JsonProperty("value")]
      public string value { get; set; }
    }
    
    /// <summary>
    /// List of card information
    /// </summary>
    public interface MinimalCardInterface {
      /// <summary>
      /// When the card was created
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// Information about the card creator
      /// </summary>
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      /// <summary>
      /// The card email address
      /// </summary>
      [JsonProperty("emailMessagingAddress")]
      public string emailMessagingAddress { get; set; }
    
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The card title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// The card UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    }
    
    #region MinimalField
    /// <summary>
    /// Field information
    /// </summary>
    public class MinimalField : MinimalFieldInterface {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("help")]
      public string help { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// field index
      /// </summary>
      [JsonProperty("index")]
      public float? index { get; set; }
    
      /// <summary>
      /// field index name
      /// </summary>
      [JsonProperty("index_name")]
      public string index_name { get; set; }
    
      /// <summary>
      /// The field internal ID
      /// </summary>
      [JsonProperty("internal_id")]
      public string internal_id { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// The options of the Checklist, Radio or Select field
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time, formula, dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field Universally Unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Field information
    /// </summary>
    public interface MinimalFieldInterface {
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("help")]
      public string help { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// field index
      /// </summary>
      [JsonProperty("index")]
      public float? index { get; set; }
    
      /// <summary>
      /// field index name
      /// </summary>
      [JsonProperty("index_name")]
      public string index_name { get; set; }
    
      /// <summary>
      /// The field internal ID
      /// </summary>
      [JsonProperty("internal_id")]
      public string internal_id { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// The options of the Checklist, Radio or Select field
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time, formula, dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field Universally Unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    }
    
    /// <summary>
    /// Phase information
    /// </summary>
    public interface MinimalPhaseInterface {
      /// <summary>
      /// The phase ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The phase name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    }
    
    #region MoveCardToPhaseInput
    /// <summary>
    /// Autogenerated input type of MoveCardToPhase
    /// </summary>
    public class MoveCardToPhaseInput {
      #region members
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonRequired]
      public string card_id { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      [JsonRequired]
      public string destination_phase_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region MoveCardToPhasePayload
    /// <summary>
    /// Autogenerated return type of MoveCardToPhase
    /// </summary>
    public class MoveCardToPhasePayload {
      #region members
      /// <summary>
      /// Returns information about the card
      /// </summary>
      [JsonProperty("card")]
      public Card card { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
      #endregion
    }
    #endregion
    
    #region Mutation
    /// <summary>
    /// The root query for implementing GraphQL mutations
    /// </summary>
    public class Mutation {
      #region members
      /// <summary>
      /// Create new cards from a xlsx file
      /// </summary>
      [JsonProperty("cardsImporter")]
      public CardsImporterPayload cardsImporter { get; set; }
    
      /// <summary>
      /// Clones a pipe
      /// </summary>
      [JsonProperty("clonePipes")]
      public ClonePipesPayload clonePipes { get; set; }
    
      [JsonProperty("configurePublicPhaseFormLink")]
      public PublicPhaseFormLink configurePublicPhaseFormLink { get; set; }
    
      /// <summary>
      /// Creates a card
      /// </summary>
      [JsonProperty("createCard")]
      public CreateCardPayload createCard { get; set; }
    
      /// <summary>
      /// Creates a card relation
      /// </summary>
      [JsonProperty("createCardRelation")]
      public CreateCardRelationPayload createCardRelation { get; set; }
    
      /// <summary>
      /// Creates a comment
      /// </summary>
      [JsonProperty("createComment")]
      public CreateCommentPayload createComment { get; set; }
    
      /// <summary>
      /// Creates a field condition
      /// </summary>
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("createFieldCondition")]
      public createFieldConditionPayload createFieldCondition { get; set; }
    
      /// <summary>
      /// Creates an email
      /// </summary>
      [JsonProperty("createInboxEmail")]
      public CreateInboxEmailPayload createInboxEmail { get; set; }
    
      /// <summary>
      /// Creates a label
      /// </summary>
      [JsonProperty("createLabel")]
      public CreateLabelPayload createLabel { get; set; }
    
      /// <summary>
      /// Creates an organization
      /// </summary>
      [JsonProperty("createOrganization")]
      public CreateOrganizationPayload createOrganization { get; set; }
    
      /// <summary>
      /// Creates an organization-level webhook
      /// </summary>
      [JsonProperty("createOrganizationWebhook")]
      public CreateOrganizationWebhookPayload createOrganizationWebhook { get; set; }
    
      /// <summary>
      /// Creates a phase
      /// </summary>
      [JsonProperty("createPhase")]
      public CreatePhasePayload createPhase { get; set; }
    
      /// <summary>
      /// Creates a phase field
      /// </summary>
      [JsonProperty("createPhaseField")]
      public CreatePhaseFieldPayload createPhaseField { get; set; }
    
      /// <summary>
      /// Creates a pipe
      /// </summary>
      [JsonProperty("createPipe")]
      public CreatePipePayload createPipe { get; set; }
    
      /// <summary>
      /// Creates a pipe relation
      /// </summary>
      [JsonProperty("createPipeRelation")]
      public CreatePipeRelationPayload createPipeRelation { get; set; }
    
      /// <summary>
      /// Returns a temporary S3 presigned url to upload a file
      /// </summary>
      [JsonProperty("createPresignedUrl")]
      public CreatePresignedUrlPayload createPresignedUrl { get; set; }
    
      /// <summary>
      /// Returns a temporary S3 presigned url to upload a pdf template image
      /// </summary>
      [JsonProperty("createPresignedUrlForPipePdfTemplate")]
      public CreatePresignedUrlForPipePdfTemplatePayload createPresignedUrlForPipePdfTemplate { get; set; }
    
      /// <summary>
      /// Creates a table
      /// </summary>
      [JsonProperty("createTable")]
      public CreateTablePayload createTable { get; set; }
    
      /// <summary>
      /// Creates a table field
      /// </summary>
      [JsonProperty("createTableField")]
      public CreateTableFieldPayload createTableField { get; set; }
    
      /// <summary>
      /// Creates a record
      /// </summary>
      [JsonProperty("createTableRecord")]
      public CreateTableRecordPayload createTableRecord { get; set; }
    
      /// <summary>
      /// Creates a record in a private table
      /// </summary>
      [JsonProperty("createTableRecordInRestrictedTable")]
      public CreateTableRecordInRestrictedTablePayload createTableRecordInRestrictedTable { get; set; }
    
      /// <summary>
      /// Creates a table relation
      /// </summary>
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("createTableRelation")]
      public CreateTableRelationPayload createTableRelation { get; set; }
    
      /// <summary>
      /// Creates a webhook at a pipe or table level
      /// </summary>
      [JsonProperty("createWebhook")]
      public CreateWebhookPayload createWebhook { get; set; }
    
      /// <summary>
      /// Deletes a card
      /// </summary>
      [JsonProperty("deleteCard")]
      public DeleteCardPayload deleteCard { get; set; }
    
      /// <summary>
      /// Deletes a comment
      /// </summary>
      [JsonProperty("deleteComment")]
      public DeleteCommentPayload deleteComment { get; set; }
    
      /// <summary>
      /// Deletes a field condition
      /// </summary>
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("deleteFieldCondition")]
      public DeleteFieldConditionPayload deleteFieldCondition { get; set; }
    
      /// <summary>
      /// Deletes an email
      /// </summary>
      [JsonProperty("deleteInboxEmail")]
      public DeleteInboxEmailPayload deleteInboxEmail { get; set; }
    
      /// <summary>
      /// Deletes a label
      /// </summary>
      [JsonProperty("deleteLabel")]
      public DeleteLabelPayload deleteLabel { get; set; }
    
      /// <summary>
      /// Deletes an organization
      /// </summary>
      [JsonProperty("deleteOrganization")]
      public DeleteOrganizationPayload deleteOrganization { get; set; }
    
      /// <summary>
      /// Deletes a webhook
      /// </summary>
      [JsonProperty("deleteOrganizationWebhook")]
      public DeleteOrganizationWebhookGQLMutationPayload deleteOrganizationWebhook { get; set; }
    
      /// <summary>
      /// Deletes a phase
      /// </summary>
      [JsonProperty("deletePhase")]
      public DeletePhasePayload deletePhase { get; set; }
    
      /// <summary>
      /// Deletes a phase field
      /// </summary>
      [JsonProperty("deletePhaseField")]
      public DeletePhaseFieldPayload deletePhaseField { get; set; }
    
      /// <summary>
      /// Deletes a pipe
      /// </summary>
      [JsonProperty("deletePipe")]
      public DeletePipePayload deletePipe { get; set; }
    
      /// <summary>
      /// Deletes a pipe relation
      /// </summary>
      [JsonProperty("deletePipeRelation")]
      public DeletePipeRelationPayload deletePipeRelation { get; set; }
    
      /// <summary>
      /// Deletes a table
      /// </summary>
      [JsonProperty("deleteTable")]
      public DeleteTablePayload deleteTable { get; set; }
    
      /// <summary>
      /// Deletes a table field
      /// </summary>
      [JsonProperty("deleteTableField")]
      public DeleteTableFieldPayload deleteTableField { get; set; }
    
      /// <summary>
      /// Deletes a record
      /// </summary>
      [JsonProperty("deleteTableRecord")]
      public DeleteTableRecordPayload deleteTableRecord { get; set; }
    
      /// <summary>
      /// Deletes a table relation
      /// </summary>
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("deleteTableRelation")]
      public DeleteTableRelationPayload deleteTableRelation { get; set; }
    
      /// <summary>
      /// Deletes a webhook (pipe or table level)
      /// </summary>
      [JsonProperty("deleteWebhook")]
      public DeleteWebhookPayload deleteWebhook { get; set; }
    
      /// <summary>
      /// Exports a pipe report
      /// </summary>
      [JsonProperty("exportPipeReport")]
      public ExportPipeReportPayload exportPipeReport { get; set; }
    
      /// <summary>
      /// Invites new members for the organization
      /// </summary>
      [JsonProperty("inviteMembers")]
      public InviteMembersPayload inviteMembers { get; set; }
    
      /// <summary>
      /// Moves a card to another phase
      /// </summary>
      [JsonProperty("moveCardToPhase")]
      public MoveCardToPhasePayload moveCardToPhase { get; set; }
    
      /// <summary>
      /// Create new records from a xlsx file
      /// </summary>
      [JsonProperty("recordsImporter")]
      public RecordsImporterPayload recordsImporter { get; set; }
    
      /// <summary>
      /// Remove a user from an organization
      /// </summary>
      [JsonProperty("removeUserFromOrg")]
      public RemoveUserFromOrgPayload removeUserFromOrg { get; set; }
    
      /// <summary>
      /// Removes a user from pipe
      /// </summary>
      [JsonProperty("removeUserFromPipe")]
      public RemoveUserFromPipePayload removeUserFromPipe { get; set; }
    
      /// <summary>
      /// Removes an user from table
      /// </summary>
      [JsonProperty("removeUserFromTable")]
      public RemoveUserFromTablePayload removeUserFromTable { get; set; }
    
      /// <summary>
      /// Sends an email
      /// </summary>
      [JsonProperty("sendInboxEmail")]
      public SendInboxEmailPayload sendInboxEmail { get; set; }
    
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("setDismissedImprovement")]
      public SetDismissedImprovementPayload setDismissedImprovement { get; set; }
    
      /// <summary>
      /// Sets field condition order
      /// </summary>
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("setFieldConditionOrder")]
      public setFieldConditionOrderPayload setFieldConditionOrder { get; set; }
    
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("setImprovementAsRead")]
      public SetImprovementAsReadPayload setImprovementAsRead { get; set; }
    
      /// <summary>
      /// Sets the role of a user
      /// </summary>
      [JsonProperty("setRole")]
      public SetRolePayload setRole { get; set; }
    
      /// <summary>
      /// Sets role of multiple users
      /// </summary>
      [JsonProperty("setRoles")]
      public SetRolesPayload setRoles { get; set; }
    
      /// <summary>
      /// Sets summary attributes
      /// </summary>
      [JsonProperty("setSummaryAttributes")]
      public SetSummaryAttributesPayload setSummaryAttributes { get; set; }
    
      /// <summary>
      /// Sets table field order
      /// </summary>
      [JsonProperty("setTableFieldOrder")]
      public SetTableFieldOrderPayload setTableFieldOrder { get; set; }
    
      /// <summary>
      /// Sets record field value
      /// </summary>
      [JsonProperty("setTableRecordFieldValue")]
      public SetTableRecordFieldValuePayload setTableRecordFieldValue { get; set; }
    
      /// <summary>
      /// Updates an existing card
      /// </summary>
      [JsonProperty("updateCard")]
      public UpdateCardPayload updateCard { get; set; }
    
      /// <summary>
      /// Updates an existing card field
      /// </summary>
      [JsonProperty("updateCardField")]
      public UpdateCardFieldPayload updateCardField { get; set; }
    
      /// <summary>
      /// Updates an existing comment
      /// </summary>
      [JsonProperty("updateComment")]
      public UpdateCommentPayload updateComment { get; set; }
    
      /// <summary>
      /// Updates an existing field condition
      /// </summary>
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("updateFieldCondition")]
      public UpdateFieldConditionPayload updateFieldCondition { get; set; }
    
      /// <summary>
      /// Update one or many values of fields inside a Card or Table record.
      /// </summary>
      [JsonProperty("updateFieldsValues")]
      public UpdateFieldsValuesPayload updateFieldsValues { get; set; }
    
      /// <summary>
      /// Updates an existing label
      /// </summary>
      [JsonProperty("updateLabel")]
      public UpdateLabelPayload updateLabel { get; set; }
    
      /// <summary>
      /// Updates an existing organization
      /// </summary>
      [JsonProperty("updateOrganization")]
      public UpdateOrganizationPayload updateOrganization { get; set; }
    
      /// <summary>
      /// Updates an existing organization-level webhook
      /// </summary>
      [JsonProperty("updateOrganizationWebhook")]
      public UpdateOrganizationWebhookPayload updateOrganizationWebhook { get; set; }
    
      /// <summary>
      /// Updates an existing phase
      /// </summary>
      [JsonProperty("updatePhase")]
      public UpdatePhasePayload updatePhase { get; set; }
    
      /// <summary>
      /// Updates an existing phase field
      /// </summary>
      [JsonProperty("updatePhaseField")]
      public UpdatePhaseFieldPayload updatePhaseField { get; set; }
    
      /// <summary>
      /// Updates an existing pipe
      /// </summary>
      [JsonProperty("updatePipe")]
      public UpdatePipePayload updatePipe { get; set; }
    
      /// <summary>
      /// Updates an existing pipe relation
      /// </summary>
      [JsonProperty("updatePipeRelation")]
      public UpdatePipeRelationPayload updatePipeRelation { get; set; }
    
      /// <summary>
      /// Updates an existing table
      /// </summary>
      [JsonProperty("updateTable")]
      public UpdateTablePayload updateTable { get; set; }
    
      /// <summary>
      /// Updates an existing table field
      /// </summary>
      [JsonProperty("updateTableField")]
      public UpdateTableFieldPayload updateTableField { get; set; }
    
      /// <summary>
      /// Updates an existing record
      /// </summary>
      [JsonProperty("updateTableRecord")]
      public UpdateTableRecordPayload updateTableRecord { get; set; }
    
      /// <summary>
      /// Updates an existing table relation
      /// </summary>
      [Obsolete("Mutation will be removed in the next update")]
      [JsonProperty("updateTableRelation")]
      public UpdateTableRelationPayload updateTableRelation { get; set; }
    
      /// <summary>
      /// Updates an existing webhook (pipe or table level)
      /// </summary>
      [JsonProperty("updateWebhook")]
      public UpdateWebhookPayload updateWebhook { get; set; }
      #endregion
    }
    #endregion
    
    #region NodeFieldValueInput
    /// <summary>
    /// Update field value by replacing the entire value, or adding and removing specific values.
    /// </summary>
    public class NodeFieldValueInput {
      #region members
      /// <summary>
      /// The ID of the Field.
      /// </summary>
      [JsonRequired]
      public string fieldId { get; set; }
    
      /// <summary>
      /// Set the operation for the value, we allow to `replace` the entire value or use `add` or `remove` to append or remove the existing list of values, that's usefull and compatible for Labels, Assignees, Attachment, Connections and Checkbox field types. Default: `replace`
      /// </summary>
      public UpdateFieldValuesOperators? operation { get; set; }
    
      /// <summary>
      /// Value that will be used to replace, add or remove based on the operation.
      /// </summary>
      public List<any> value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region NumberField
    /// <summary>
    /// The number field
    /// </summary>
    public class NumberField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Number field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public float? initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region Organization
    /// <summary>
    /// List of organization information
    /// </summary>
    public class Organization : OrganizationInterface {
      #region members
      /// <summary>
      /// Organization billing infos
      /// </summary>
      [JsonProperty("billing")]
      public Billing billing { get; set; }
    
      /// <summary>
      /// When the organization was created
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// User that created the organization
      /// </summary>
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      /// <summary>
      /// When the organization was created
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `createdAt` instead.")]
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// The organization logo URL
      /// </summary>
      [JsonProperty("customLogoUrl")]
      public string customLogoUrl { get; set; }
    
      /// <summary>
      /// The organization logo URL
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `customLogoUrl` instead.")]
      [JsonProperty("custom_logo_url")]
      public string custom_logo_url { get; set; }
    
      [JsonProperty("freemium")]
      public bool? freemium { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Information about the organization members
      /// </summary>
      [JsonProperty("members")]
      public List<Member> members { get; set; }
    
      /// <summary>
      /// Quantity of members of the organization
      /// </summary>
      [JsonProperty("membersCount")]
      public int? membersCount { get; set; }
    
      /// <summary>
      /// Quantity of members of the organization by role
      /// </summary>
      [JsonProperty("membersCountByRole")]
      public List<Role> membersCountByRole { get; set; }
    
      /// <summary>
      /// The organization name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Whether only Admins can create pipes
      /// </summary>
      [JsonProperty("onlyAdminCanCreatePipes")]
      public bool? onlyAdminCanCreatePipes { get; set; }
    
      /// <summary>
      /// Whether only Admins can invite new users
      /// </summary>
      [JsonProperty("onlyAdminCanInviteUsers")]
      public bool? onlyAdminCanInviteUsers { get; set; }
    
      /// <summary>
      /// Whether only Admins can create pipes
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `onlyAdminCanCreatePipes` instead.")]
      [JsonProperty("only_admin_can_create_pipes")]
      public bool? only_admin_can_create_pipes { get; set; }
    
      /// <summary>
      /// Whether only Admins can invite new users
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `onlyAdminCanInviteUsers` instead.")]
      [JsonProperty("only_admin_can_invite_users")]
      public bool? only_admin_can_invite_users { get; set; }
    
      /// <summary>
      /// User permissions for this org
      /// </summary>
      [JsonProperty("permissions")]
      public OrganizationPermissionsInternalGQLType permissions { get; set; }
    
      /// <summary>
      /// Fetches a group of pipes based on arguments
      /// </summary>
      [JsonProperty("pipes")]
      public List<Pipe> pipes { get; set; }
    
      /// <summary>
      /// Quantity of pipes of the organization
      /// </summary>
      [JsonProperty("pipesCount")]
      public int? pipesCount { get; set; }
    
      [JsonProperty("planName")]
      public string planName { get; set; }
    
      /// <summary>
      /// Current user's role in the organization
      /// </summary>
      [JsonProperty("role")]
      public string role { get; set; }
    
      /// <summary>
      /// Fetches a group of database tables based on arguments
      /// </summary>
      [JsonProperty("tables")]
      public TableConnection tables { get; set; }
    
      /// <summary>
      /// Info on user metadata related to the current organization
      /// </summary>
      [JsonProperty("userMetadata")]
      public OrganizationUserMetadata userMetadata { get; set; }
    
      /// <summary>
      /// Information about the organization users
      /// </summary>
      [JsonProperty("users")]
      public List<User> users { get; set; }
    
      /// <summary>
      /// Quantity of members of the organization
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `membersCount` instead.")]
      [JsonProperty("users_count")]
      public int? users_count { get; set; }
    
      /// <summary>
      /// The organization UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    
      /// <summary>
      /// Information about the organization Webhooks
      /// </summary>
      [JsonProperty("webhooks")]
      public List<Webhook> webhooks { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// List of organization information
    /// </summary>
    public interface OrganizationInterface {
      /// <summary>
      /// Organization billing infos
      /// </summary>
      [JsonProperty("billing")]
      public Billing billing { get; set; }
    
      /// <summary>
      /// When the organization was created
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// User that created the organization
      /// </summary>
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      /// <summary>
      /// When the organization was created
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `createdAt` instead.")]
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// The organization logo URL
      /// </summary>
      [JsonProperty("customLogoUrl")]
      public string customLogoUrl { get; set; }
    
      /// <summary>
      /// The organization logo URL
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `customLogoUrl` instead.")]
      [JsonProperty("custom_logo_url")]
      public string custom_logo_url { get; set; }
    
      [JsonProperty("freemium")]
      public bool? freemium { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Information about the organization members
      /// </summary>
      [JsonProperty("members")]
      public List<Member> members { get; set; }
    
      /// <summary>
      /// Quantity of members of the organization
      /// </summary>
      [JsonProperty("membersCount")]
      public int? membersCount { get; set; }
    
      /// <summary>
      /// Quantity of members of the organization by role
      /// </summary>
      [JsonProperty("membersCountByRole")]
      public List<Role> membersCountByRole { get; set; }
    
      /// <summary>
      /// The organization name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Whether only Admins can create pipes
      /// </summary>
      [JsonProperty("onlyAdminCanCreatePipes")]
      public bool? onlyAdminCanCreatePipes { get; set; }
    
      /// <summary>
      /// Whether only Admins can invite new users
      /// </summary>
      [JsonProperty("onlyAdminCanInviteUsers")]
      public bool? onlyAdminCanInviteUsers { get; set; }
    
      /// <summary>
      /// Whether only Admins can create pipes
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `onlyAdminCanCreatePipes` instead.")]
      [JsonProperty("only_admin_can_create_pipes")]
      public bool? only_admin_can_create_pipes { get; set; }
    
      /// <summary>
      /// Whether only Admins can invite new users
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `onlyAdminCanInviteUsers` instead.")]
      [JsonProperty("only_admin_can_invite_users")]
      public bool? only_admin_can_invite_users { get; set; }
    
      /// <summary>
      /// User permissions for this org
      /// </summary>
      [JsonProperty("permissions")]
      public OrganizationPermissionsInternalGQLType permissions { get; set; }
    
      /// <summary>
      /// Fetches a group of pipes based on arguments
      /// </summary>
      [JsonProperty("pipes")]
      public List<Pipe> pipes { get; set; }
    
      /// <summary>
      /// Quantity of pipes of the organization
      /// </summary>
      [JsonProperty("pipesCount")]
      public int? pipesCount { get; set; }
    
      [JsonProperty("planName")]
      public string planName { get; set; }
    
      /// <summary>
      /// Current user's role in the organization
      /// </summary>
      [JsonProperty("role")]
      public string role { get; set; }
    
      /// <summary>
      /// Fetches a group of database tables based on arguments
      /// </summary>
      [JsonProperty("tables")]
      public TableConnection tables { get; set; }
    
      /// <summary>
      /// Info on user metadata related to the current organization
      /// </summary>
      [JsonProperty("userMetadata")]
      public OrganizationUserMetadata userMetadata { get; set; }
    
      /// <summary>
      /// Information about the organization users
      /// </summary>
      [JsonProperty("users")]
      public List<User> users { get; set; }
    
      /// <summary>
      /// Quantity of members of the organization
      /// </summary>
      [Obsolete("This field is deprecated.
        Use `membersCount` instead.")]
      [JsonProperty("users_count")]
      public int? users_count { get; set; }
    
      /// <summary>
      /// The organization UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    
      /// <summary>
      /// Information about the organization Webhooks
      /// </summary>
      [JsonProperty("webhooks")]
      public List<Webhook> webhooks { get; set; }
    }
    
    #region OrganizationPermissionsInternalGQLType
    /// <summary>
    /// Org permissions for the given user
    /// </summary>
    public class OrganizationPermissionsInternalGQLType {
      #region members
      [JsonProperty("canManageCustomRoles")]
      public bool? canManageCustomRoles { get; set; }
    
      [JsonProperty("inviteMember")]
      public bool inviteMember { get; set; }
    
      [JsonProperty("showAdminPortal")]
      public bool showAdminPortal { get; set; }
    
      [JsonProperty("showCompanyActivities")]
      public bool showCompanyActivities { get; set; }
    
      [JsonProperty("showCompanyReports")]
      public bool showCompanyReports { get; set; }
    
      [JsonProperty("showCreateDatabases")]
      public bool? showCreateDatabases { get; set; }
    
      [JsonProperty("showCreatePipeBanner")]
      public bool showCreatePipeBanner { get; set; }
    
      [JsonProperty("showDashboard")]
      public bool showDashboard { get; set; }
    
      [JsonProperty("showDashboardMobile")]
      public bool showDashboardMobile { get; set; }
    
      [JsonProperty("showInviteMember")]
      public bool showInviteMember { get; set; }
    
      [JsonProperty("showMyTasks")]
      public bool showMyTasks { get; set; }
    
      [JsonProperty("showPortals")]
      public bool showPortals { get; set; }
    
      [JsonProperty("showRepoList")]
      public bool showRepoList { get; set; }
      #endregion
    }
    #endregion
    
    #region OrganizationUserMetadata
    /// <summary>
    /// Info on user metadata related to the current organization
    /// </summary>
    public class OrganizationUserMetadata {
      #region members
      /// <summary>
      /// Whether the user can create a new pipe
      /// </summary>
      [JsonProperty("canCreatePipe")]
      public bool canCreatePipe { get; set; }
    
      /// <summary>
      /// Whether the user can invite another user to this organization or not
      /// </summary>
      [JsonProperty("canInviteUser")]
      public bool canInviteUser { get; set; }
      #endregion
    }
    #endregion
    
    #region PageInfo
    /// <summary>
    /// Information about pagination in a connection.
    /// </summary>
    public class PageInfo {
      #region members
      /// <summary>
      /// When paginating forwards, the cursor to continue.
      /// </summary>
      [JsonProperty("endCursor")]
      public string endCursor { get; set; }
    
      /// <summary>
      /// When paginating forwards, are there more items?
      /// </summary>
      [JsonProperty("hasNextPage")]
      public bool hasNextPage { get; set; }
    
      /// <summary>
      /// When paginating backwards, are there more items?
      /// </summary>
      [JsonProperty("hasPreviousPage")]
      public bool hasPreviousPage { get; set; }
    
      /// <summary>
      /// When paginating backwards, the cursor to continue.
      /// </summary>
      [JsonProperty("startCursor")]
      public string startCursor { get; set; }
      #endregion
    }
    #endregion
    
    #region Phase
    /// <summary>
    /// List of phase information
    /// </summary>
    public class Phase : MinimalPhaseInterface {
      #region members
      /// <summary>
      /// Phase can receive cards directly from draft?
      /// </summary>
      [JsonProperty("can_receive_card_directly_from_draft")]
      public bool? can_receive_card_directly_from_draft { get; set; }
    
      /// <summary>
      /// Fetches a group of cards based on arguments
      /// </summary>
      [JsonProperty("cards")]
      public CardConnection cards { get; set; }
    
      /// <summary>
      /// Information about the phases that the cards can be moved to
      /// </summary>
      [JsonProperty("cards_can_be_moved_to_phases")]
      public List<Phase> cards_can_be_moved_to_phases { get; set; }
    
      /// <summary>
      /// The phase total cards
      /// </summary>
      [JsonProperty("cards_count")]
      public int? cards_count { get; set; }
    
      /// <summary>
      /// Color of phase
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// When the phase was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Custom sorting preferences
      /// </summary>
      [JsonProperty("custom_sorting_preferences")]
      public any custom_sorting_preferences { get; set; }
    
      /// <summary>
      /// The phase description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Whether it is a final phase
      /// </summary>
      [JsonProperty("done")]
      public bool done { get; set; }
    
      /// <summary>
      /// The phase total expired cards
      /// </summary>
      [JsonProperty("expiredCardsCount")]
      public int? expiredCardsCount { get; set; }
    
      /// <summary>
      /// Information about the phase field conditions
      /// </summary>
      [JsonProperty("fieldConditions")]
      public List<FieldCondition> fieldConditions { get; set; }
    
      /// <summary>
      /// Information about the fields
      /// </summary>
      [JsonProperty("fields")]
      public List<PhaseField> fields { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The phase positional index
      /// </summary>
      [JsonProperty("index")]
      public float? index { get; set; }
    
      /// <summary>
      /// Is this phase draft?
      /// </summary>
      [JsonProperty("isDraft")]
      public bool? isDraft { get; set; }
    
      /// <summary>
      /// The phase total late cards
      /// </summary>
      [JsonProperty("lateCardsCount")]
      public int? lateCardsCount { get; set; }
    
      /// <summary>
      /// Lateness time
      /// </summary>
      [JsonProperty("lateness_time")]
      public int? lateness_time { get; set; }
    
      /// <summary>
      /// The phase name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Information about the next phases the cards can be moved to
      /// </summary>
      [JsonProperty("next_phase_ids")]
      public List<int?> next_phase_ids { get; set; }
    
      /// <summary>
      /// Information about the previous phases that the cards can be moved to
      /// </summary>
      [JsonProperty("previous_phase_ids")]
      public List<int?> previous_phase_ids { get; set; }
    
      /// <summary>
      /// Phase repo ID
      /// </summary>
      [JsonProperty("repo_id")]
      public int? repo_id { get; set; }
    
      /// <summary>
      /// The sequential identifier
      /// </summary>
      [JsonProperty("sequentialId")]
      public string sequentialId { get; set; }
    
      /// <summary>
      /// The phase universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region PhaseDetail
    /// <summary>
    /// List of the phase history information.
    /// </summary>
    public class PhaseDetail {
      #region members
      /// <summary>
      /// Whether or not the card ever became late on a phase.
      /// </summary>
      [JsonProperty("became_late")]
      public bool? became_late { get; set; }
    
      /// <summary>
      /// Represents the date and time of when the card first entered the phase.
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Whether or not the phase detail is in the start form.
      /// </summary>
      [JsonProperty("draft")]
      public bool? draft { get; set; }
    
      /// <summary>
      /// Represents the seconds card stayed in the phase.
      /// </summary>
      [JsonProperty("duration")]
      public int? duration { get; set; }
    
      /// <summary>
      /// Represents the date and time of when card first entered the phase.
      /// </summary>
      [JsonProperty("firstTimeIn")]
      public any firstTimeIn { get; set; }
    
      /// <summary>
      /// Represents the date and time of when card last entered the phase.
      /// </summary>
      [JsonProperty("lastTimeIn")]
      public any lastTimeIn { get; set; }
    
      /// <summary>
      /// Represents the date and time of when card left the phase.
      /// </summary>
      [JsonProperty("lastTimeOut")]
      public any lastTimeOut { get; set; }
    
      /// <summary>
      /// Lookup the phase by its identifier.
      /// </summary>
      [JsonProperty("phase")]
      public Phase phase { get; set; }
      #endregion
    }
    #endregion
    
    #region PhaseField
    /// <summary>
    /// List of field information
    /// </summary>
    public class PhaseField : GenericField, MinimalFieldInterface {
      #region members
      /// <summary>
      /// Whether all child items must be done to finish the parent item
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToFinishParent")]
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all child items must be done to move the parent item
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToMoveParent")]
      public bool? allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether it's possible to connect existing items
      /// </summary>
      [JsonProperty("canConnectExisting")]
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Whether it's possible to connect multiple items
      /// </summary>
      [JsonProperty("canConnectMultiples")]
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Whether its possible to create new connected items
      /// </summary>
      [JsonProperty("canCreateNewConnected")]
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonProperty("childMustExistToFinishParent")]
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Repo (Pipe or Table) representation
      /// </summary>
      [JsonProperty("connectedRepo")]
      public PublicRepoUnion connectedRepo { get; set; }
    
      /// <summary>
      /// Repo (Pipe or Table) representation
      /// </summary>
      [Obsolete("connected_repo has been replaced by connectedRepo")]
      [JsonProperty("connected_repo")]
      public RepoTypes connected_repo { get; set; }
    
      /// <summary>
      /// The regex used to validate the field value
      /// </summary>
      [JsonProperty("custom_validation")]
      public string custom_validation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Whether the field is editable in future phases
      /// </summary>
      [JsonProperty("editable")]
      public bool? editable { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("help")]
      public string help { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// field index
      /// </summary>
      [JsonProperty("index")]
      public float? index { get; set; }
    
      /// <summary>
      /// field index name
      /// </summary>
      [JsonProperty("index_name")]
      public string index_name { get; set; }
    
      /// <summary>
      /// The field internal ID
      /// </summary>
      [JsonProperty("internal_id")]
      public string internal_id { get; set; }
    
      /// <summary>
      /// Whether the field accepts multiple entries
      /// </summary>
      [JsonProperty("is_multiple")]
      public bool? is_multiple { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimal_view")]
      public bool? minimal_view { get; set; }
    
      /// <summary>
      /// The options of the Checklist, Radio or Select field
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// Information about the phase
      /// </summary>
      [JsonProperty("phase")]
      public Phase phase { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("required")]
      public bool? required { get; set; }
    
      /// <summary>
      /// Whether the phase field is synchronized with the fix field
      /// </summary>
      [JsonProperty("synced_with_card")]
      public bool? synced_with_card { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time, formula, dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field Universally Unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region PhaseFieldConnection
    /// <summary>
    /// The connection type for PhaseField.
    /// </summary>
    public class PhaseFieldConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<PhaseFieldEdge> edges { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region PhaseFieldEdge
    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class PhaseFieldEdge {
      #region members
      /// <summary>
      /// A cursor for use in pagination.
      /// </summary>
      [JsonProperty("cursor")]
      public string cursor { get; set; }
    
      /// <summary>
      /// The item at the end of the edge.
      /// </summary>
      [JsonProperty("node")]
      public PhaseField node { get; set; }
      #endregion
    }
    #endregion
    
    #region PhaseFieldInput
    /// <summary>
    /// Phase field's inputs
    /// </summary>
    public class PhaseFieldInput {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// Whether the field is editable
      /// </summary>
      public bool? editable { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      public string help { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonRequired]
      public string label { get; set; }
    
      /// <summary>
      /// The options of the Checklist, Radio or Select field
      /// </summary>
      public List<string> options { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      public string phase_id { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      public bool? required { get; set; }
    
      /// <summary>
      /// Whether the field is sync with the fixed field
      /// </summary>
      public bool? sync_with_card { get; set; }
    
      /// <summary>
      /// The field type
      /// 
      /// Valid options:
      /// - assignee_select
      /// - attachment
      /// - checklist_horizontal
      /// - checklist_vertical
      /// - cnpj
      /// - connector
      /// - cpf
      /// - currency
      /// - date
      /// - datetime
      /// - due_date
      /// - email
      /// - id
      /// - label_select
      /// - long_text
      /// - number
      /// - phone
      /// - radio_horizontal
      /// - radio_vertical
      /// - select
      /// - short_text
      /// - statement
      /// - time
      /// </summary>
      [JsonRequired]
      public string type_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region PhaseInput
    /// <summary>
    /// Phase's inputs
    /// </summary>
    public class PhaseInput {
      #region members
      /// <summary>
      /// Whether its a final phase
      /// </summary>
      public bool? done { get; set; }
    
      /// <summary>
      /// The phase name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region PhoneField
    /// <summary>
    /// The phone field
    /// </summary>
    public class PhoneField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Phone field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region Pipe
    /// <summary>
    /// List of pipe information
    /// </summary>
    public class Pipe : PipeSharedProperties, PublicPipeInterface, Repo {
      #region members
      /// <summary>
      /// Whether anyone can create cards in the pipe
      /// </summary>
      [JsonProperty("anyone_can_create_card")]
      public bool? anyone_can_create_card { get; set; }
    
      /// <summary>
      /// The pipe total cards
      /// </summary>
      [JsonProperty("cards_count")]
      public int? cards_count { get; set; }
    
      /// <summary>
      /// Information about the pipe child connections
      /// </summary>
      [JsonProperty("childrenRelations")]
      public List<PipeRelation> childrenRelations { get; set; }
    
      /// <summary>
      /// Id which the Pipe was cloned from
      /// </summary>
      [JsonProperty("clone_from_id")]
      public int? clone_from_id { get; set; }
    
      /// <summary>
      /// Color of pipe/database
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// IDs of all fields in a pipe that trigger conditionals
      /// </summary>
      [JsonProperty("conditionExpressionsFieldIds")]
      public List<int?> conditionExpressionsFieldIds { get; set; }
    
      /// <summary>
      /// The content displayed in the start form button
      /// </summary>
      [JsonProperty("create_card_label")]
      public string create_card_label { get; set; }
    
      /// <summary>
      /// When the pipe was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// The Repo description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The pipe's email inbox address
      /// </summary>
      [JsonProperty("emailAddress")]
      public string emailAddress { get; set; }
    
      /// <summary>
      /// The number used in the pipe SLA
      /// </summary>
      [JsonProperty("expiration_time_by_unit")]
      public int? expiration_time_by_unit { get; set; }
    
      /// <summary>
      /// The seconds of the unit used in the pipe SLA
      /// </summary>
      [JsonProperty("expiration_unit")]
      public int? expiration_unit { get; set; }
    
      /// <summary>
      /// Information about the fields conditions
      /// </summary>
      [JsonProperty("fieldConditions")]
      public List<FieldCondition> fieldConditions { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Information about the pipe improvement setting
      /// </summary>
      [JsonProperty("improvementSetting")]
      public ImprovementSetting improvementSetting { get; set; }
    
      /// <summary>
      /// Information about the Repo labels
      /// </summary>
      [JsonProperty("labels")]
      public List<Label> labels { get; set; }
    
      /// <summary>
      /// When a card was last updated in the pipe
      /// </summary>
      [JsonProperty("last_updated_by_card")]
      public any last_updated_by_card { get; set; }
    
      /// <summary>
      /// Information about the Repo members
      /// </summary>
      [JsonProperty("members")]
      public List<Member> members { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo noun for their registries
      /// </summary>
      [JsonProperty("noun")]
      public string noun { get; set; }
    
      /// <summary>
      /// Whether only Admins can delete cards
      /// </summary>
      [JsonProperty("only_admin_can_remove_cards")]
      public bool? only_admin_can_remove_cards { get; set; }
    
      /// <summary>
      /// Whether only the card assignees can edit it
      /// </summary>
      [JsonProperty("only_assignees_can_edit_cards")]
      public bool? only_assignees_can_edit_cards { get; set; }
    
      /// <summary>
      /// The total amount of cards not done
      /// </summary>
      [JsonProperty("opened_cards_count")]
      public int? opened_cards_count { get; set; }
    
      /// <summary>
      /// Information about the organization
      /// </summary>
      [JsonProperty("organization")]
      public Organization organization { get; set; }
    
      /// <summary>
      /// Card organization id
      /// </summary>
      [JsonProperty("organizationId")]
      public string organizationId { get; set; }
    
      /// <summary>
      /// Information about the pipe parent connections
      /// </summary>
      [JsonProperty("parentsRelations")]
      public List<PipeRelation> parentsRelations { get; set; }
    
      /// <summary>
      /// User permissions for this repo
      /// </summary>
      [JsonProperty("permissions")]
      public RepoPermissionsInternalGQLType permissions { get; set; }
    
      /// <summary>
      /// Information about the pipe phases
      /// </summary>
      [JsonProperty("phases")]
      public List<Phase> phases { get; set; }
    
      /// <summary>
      /// Information about the pipe preferences
      /// </summary>
      [JsonProperty("preferences")]
      public RepoPreference preferences { get; set; }
    
      /// <summary>
      /// Whether the Repo is public
      /// </summary>
      [JsonProperty("public")]
      public bool? @public { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [JsonProperty("publicForm")]
      public PublicFormInternal publicForm { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm` instead.")]
      [JsonProperty("publicFormSettings")]
      public PublicFormSettings publicFormSettings { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form")]
      public bool? public_form { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form_active")]
      public bool? public_form_active { get; set; }
    
      /// <summary>
      /// The pipe's reports
      /// </summary>
      [JsonProperty("reports")]
      public List<PipeReport> reports { get; set; }
    
      /// <summary>
      /// The current user role in the pipe
      /// </summary>
      [JsonProperty("role")]
      public string role { get; set; }
    
      /// <summary>
      /// Information about the start form fields conditions
      /// </summary>
      [JsonProperty("startFormFieldConditions")]
      public List<FieldCondition> startFormFieldConditions { get; set; }
    
      /// <summary>
      /// The repo start form phase id
      /// </summary>
      [JsonProperty("startFormPhaseId")]
      public string startFormPhaseId { get; set; }
    
      /// <summary>
      /// Information about the start form fields
      /// </summary>
      [JsonProperty("start_form_fields")]
      public List<PhaseField> start_form_fields { get; set; }
    
      /// <summary>
      /// Fields used that is set as subtitle
      /// </summary>
      [JsonProperty("subtitleFields")]
      public PhaseFieldConnection subtitleFields { get; set; }
    
      /// <summary>
      /// The pipe Small Unique ID
      /// </summary>
      [JsonProperty("suid")]
      public string suid { get; set; }
    
      /// <summary>
      /// Information about the data selected to be shown in the summarized view
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<SummaryAttribute> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the Repo summary options
      /// </summary>
      [JsonProperty("summary_options")]
      public List<SummaryGroup> summary_options { get; set; }
    
      /// <summary>
      /// Information about the field selected to be the card title
      /// </summary>
      [JsonProperty("title_field")]
      public PhaseField title_field { get; set; }
    
      /// <summary>
      /// Information about the pipe users
      /// </summary>
      [JsonProperty("users")]
      public List<User> users { get; set; }
    
      /// <summary>
      /// The total users in the pipe
      /// </summary>
      [JsonProperty("users_count")]
      public int? users_count { get; set; }
    
      /// <summary>
      /// Unique identifier id
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    
      /// <summary>
      /// Information about the pipe Webhooks
      /// </summary>
      [JsonProperty("webhooks")]
      public List<Webhook> webhooks { get; set; }
      #endregion
    }
    #endregion
    
    #region PipeRelation
    /// <summary>
    /// List of the pipe's relation information.
    /// </summary>
    public class PipeRelation : RepoConnection {
      #region members
      /// <summary>
      /// Whether all children must be done to finish the parent
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToFinishParent")]
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all children must be done to move the parent
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToMoveParent")]
      public bool? allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether or not the auto fill is enabled in the relation.
      /// </summary>
      [JsonProperty("autoFillFieldEnabled")]
      public bool? autoFillFieldEnabled { get; set; }
    
      /// <summary>
      /// Whether its possible to connect existing items
      /// </summary>
      [JsonProperty("canConnectExistingItems")]
      public bool? canConnectExistingItems { get; set; }
    
      /// <summary>
      /// Whether its possible to connect multiple items
      /// </summary>
      [JsonProperty("canConnectMultipleItems")]
      public bool? canConnectMultipleItems { get; set; }
    
      /// <summary>
      /// Whether its possible to create new connected items
      /// </summary>
      [JsonProperty("canCreateNewItems")]
      public bool? canCreateNewItems { get; set; }
    
      /// <summary>
      /// Information about the child Repo
      /// </summary>
      [JsonProperty("child")]
      public RepoTypes child { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonProperty("childMustExistToFinishParent")]
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Whether a child must exist to move the parent
      /// </summary>
      [JsonProperty("childMustExistToMoveParent")]
      public bool? childMustExistToMoveParent { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The relation name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Represents a map of fields of a parent-item to auto fill fields of a child-item's start form.
      /// </summary>
      [JsonProperty("ownFieldMaps")]
      public List<FieldMap> ownFieldMaps { get; set; }
    
      /// <summary>
      /// Information about the parent Repo
      /// </summary>
      [JsonProperty("parent")]
      public RepoTypes parent { get; set; }
      #endregion
    }
    #endregion
    
    #region PipeReport
    /// <summary>
    /// Lookup a organization report by its ID
    /// </summary>
    public class PipeReport {
      #region members
      /// <summary>
      /// How many cards are returned in the report
      /// </summary>
      [JsonProperty("cardCount")]
      public int cardCount { get; set; }
    
      /// <summary>
      /// Color of report
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// When the report was created
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// Featured formula that summarizes the Report 
      /// </summary>
      [JsonProperty("featuredField")]
      public string featuredField { get; set; }
    
      /// <summary>
      /// Fields to show in the report
      /// </summary>
      [JsonProperty("fields")]
      public List<string> fields { get; set; }
    
      /// <summary>
      /// Filter to report
      /// </summary>
      [JsonProperty("filter")]
      public any filter { get; set; }
    
      /// <summary>
      /// The report identifier
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// When the report was last updated
      /// </summary>
      [JsonProperty("lastUpdatedAt")]
      public any lastUpdatedAt { get; set; }
    
      /// <summary>
      /// When the exportation took place
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Formula fields selected for the report
      /// </summary>
      [JsonProperty("selectedFormulaFields")]
      public List<PipeReportFormulaField> selectedFormulaFields { get; set; }
    
      /// <summary>
      /// How cards are sorted in the report.
      /// </summary>
      [JsonProperty("sortBy")]
      public ReportSortDirection sortBy { get; set; }
      #endregion
    }
    #endregion
    
    #region PipeReportExport
    /// <summary>
    /// Lookup a organization report export by its ID
    /// </summary>
    public class PipeReportExport {
      #region members
      /// <summary>
      /// The location of the exported file
      /// </summary>
      [JsonProperty("fileURL")]
      public string fileURL { get; set; }
    
      /// <summary>
      /// When the exportation finished executing
      /// </summary>
      [JsonProperty("finishedAt")]
      public any finishedAt { get; set; }
    
      /// <summary>
      /// The report export identifier
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The user who requested the exportation
      /// </summary>
      [JsonProperty("report")]
      public PipeReport report { get; set; }
    
      /// <summary>
      /// The user who requested the exportation
      /// </summary>
      [JsonProperty("requestedBy")]
      public User requestedBy { get; set; }
    
      /// <summary>
      /// When the exportation took place
      /// </summary>
      [JsonProperty("startedAt")]
      public any startedAt { get; set; }
    
      /// <summary>
      /// The exportation current state
      /// </summary>
      [JsonProperty("state")]
      public ExportationState state { get; set; }
      #endregion
    }
    #endregion
    
    #region PipeReportFormulaField
    public class PipeReportFormulaField {
      #region members
      /// <summary>
      /// formula field average value
      /// </summary>
      [JsonProperty("avg")]
      public float? avg { get; set; }
    
      /// <summary>
      /// formula field count value
      /// </summary>
      [JsonProperty("count")]
      public float? count { get; set; }
    
      /// <summary>
      /// formula field index name
      /// </summary>
      [JsonProperty("indexName")]
      public string indexName { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// formula field max value
      /// </summary>
      [JsonProperty("max")]
      public float? max { get; set; }
    
      /// <summary>
      /// formula field min value
      /// </summary>
      [JsonProperty("min")]
      public float? min { get; set; }
    
      /// <summary>
      /// formula field selected formula
      /// </summary>
      [JsonProperty("selectedFormula")]
      public string selectedFormula { get; set; }
    
      /// <summary>
      /// formula field sum value
      /// </summary>
      [JsonProperty("sum")]
      public float? sum { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// List of attributtes that is shared between both public and internal api
    /// </summary>
    public interface PipeSharedProperties {
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The total amount of cards not done
      /// </summary>
      [JsonProperty("opened_cards_count")]
      public int? opened_cards_count { get; set; }
    
      /// <summary>
      /// The current user role in the pipe
      /// </summary>
      [JsonProperty("role")]
      public string role { get; set; }
    
      /// <summary>
      /// The pipe UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    }
    
    #region PipeTemplate
    /// <summary>
    /// List of the pipe templates information.
    /// </summary>
    public class PipeTemplate {
      #region members
      /// <summary>
      /// Represents the name of the icon selected to represent the template.
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// Represents the template identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the name of the image selected to represent the template.
      /// </summary>
      [JsonProperty("image")]
      public string image { get; set; }
    
      /// <summary>
      /// Represents the template name.
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region PlatformApp
    /// <summary>
    /// PlatformApps used in the Repo
    /// </summary>
    public class PlatformApp {
      #region members
      /// <summary>
      /// The attachments of the app for a given card
      /// </summary>
      [JsonProperty("attachments_connection")]
      public AppAttachmentConnection attachments_connection { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("name")]
      public string name { get; set; }
    
      [JsonProperty("public")]
      public bool? @public { get; set; }
    
      [JsonProperty("slug")]
      public string slug { get; set; }
    
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicCard
    /// <summary>
    /// Card information
    /// </summary>
    public class PublicCard : PublicRepoItemInterface {
      #region members
      /// <summary>
      /// When the record was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Information about icon name and color
      /// </summary>
      [JsonProperty("icon")]
      public Icon icon { get; set; }
    
      /// <summary>
      /// The item ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The item path
      /// </summary>
      [JsonProperty("path")]
      public string path { get; set; }
    
      /// <summary>
      /// The record status
      /// </summary>
      [JsonProperty("status")]
      public TableRecordStatus status { get; set; }
    
      /// <summary>
      /// The item summary layout information
      /// </summary>
      [JsonProperty("summary")]
      public List<Summary> summary { get; set; }
    
      /// <summary>
      /// Information about the repo item attributes summary layout
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<Summary> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the repo item custom fields summary layout
      /// </summary>
      [JsonProperty("summary_fields")]
      public List<Summary> summary_fields { get; set; }
    
      /// <summary>
      /// The item title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// The URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The item uuid
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Public form common fields
    /// </summary>
    public interface PublicFormInterface {
      /// <summary>
      /// The message shown to user after submitting the public form
      /// </summary>
      [JsonProperty("afterSubmitMessage")]
      public string afterSubmitMessage { get; set; }
    
      /// <summary>
      /// The background color of the public form (RGB)
      /// </summary>
      [JsonProperty("backgroundColor")]
      public string backgroundColor { get; set; }
    
      /// <summary>
      /// The background image URL of the public form
      /// </summary>
      [JsonProperty("backgroundImage")]
      public string backgroundImage { get; set; }
    
      /// <summary>
      /// The brand color that will be used in the public form (RGB)
      /// </summary>
      [JsonProperty("brandColor")]
      public string brandColor { get; set; }
    
      /// <summary>
      /// Whether the public form creator can hide Pipefy's logo
      /// </summary>
      [JsonProperty("canHidePipefyLogo")]
      public bool? canHidePipefyLogo { get; set; }
    
      /// <summary>
      /// Description of the public form
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Whether to display Pipefy's logo in the public form
      /// </summary>
      [JsonProperty("displayPipefyLogo")]
      public bool? displayPipefyLogo { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Logo of the public form
      /// </summary>
      [JsonProperty("logo")]
      public string logo { get; set; }
    
      /// <summary>
      /// The name of the organization to be shown in the public form
      /// </summary>
      [JsonProperty("organizationName")]
      public string organizationName { get; set; }
    
      /// <summary>
      /// Fill again with the same values that were used on the last submission
      /// </summary>
      [JsonProperty("reuseLastSubmissionResponse")]
      public bool? reuseLastSubmissionResponse { get; set; }
    
      /// <summary>
      /// Whether its allowed to submit another response
      /// </summary>
      [JsonProperty("showSubmitAnotherResponseButton")]
      public bool? showSubmitAnotherResponseButton { get; set; }
    
      /// <summary>
      /// Text of the submit button on the public form
      /// </summary>
      [JsonProperty("submitButtonText")]
      public string submitButtonText { get; set; }
    
      /// <summary>
      /// Whether the submitter email collection is enabled
      /// </summary>
      [JsonProperty("submitterEmailCollectionEnabled")]
      public bool? submitterEmailCollectionEnabled { get; set; }
    
      /// <summary>
      /// The method to ask for the submitter email in the public form
      /// </summary>
      [JsonProperty("submitterEmailCollectionMethod")]
      public PublicFormSubmitterEmailCollectionMethod? submitterEmailCollectionMethod { get; set; }
    
      [JsonProperty("submitterEmailField")]
      public MinimalField submitterEmailField { get; set; }
    
      /// <summary>
      /// Title of the public form
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    }
    
    #region PublicFormInternal
    /// <summary>
    /// Public form fields used in the internal API
    /// </summary>
    public class PublicFormInternal : PublicFormInterface {
      #region members
      /// <summary>
      /// Public Form is active or not
      /// </summary>
      [JsonProperty("active")]
      public bool? active { get; set; }
    
      /// <summary>
      /// The message shown to user after submitting the public form
      /// </summary>
      [JsonProperty("afterSubmitMessage")]
      public string afterSubmitMessage { get; set; }
    
      /// <summary>
      /// The background color of the public form (RGB)
      /// </summary>
      [JsonProperty("backgroundColor")]
      public string backgroundColor { get; set; }
    
      /// <summary>
      /// The background image URL of the public form
      /// </summary>
      [JsonProperty("backgroundImage")]
      public string backgroundImage { get; set; }
    
      /// <summary>
      /// The brand color that will be used in the public form (RGB)
      /// </summary>
      [JsonProperty("brandColor")]
      public string brandColor { get; set; }
    
      /// <summary>
      /// Whether the public form creator can hide Pipefy's logo
      /// </summary>
      [JsonProperty("canHidePipefyLogo")]
      public bool? canHidePipefyLogo { get; set; }
    
      /// <summary>
      /// Description of the public form
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Whether to display Pipefy's logo in the public form
      /// </summary>
      [JsonProperty("displayPipefyLogo")]
      public bool? displayPipefyLogo { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Logo of the public form
      /// </summary>
      [JsonProperty("logo")]
      public string logo { get; set; }
    
      /// <summary>
      /// The name of the organization to be shown in the public form
      /// </summary>
      [JsonProperty("organizationName")]
      public string organizationName { get; set; }
    
      /// <summary>
      /// Fill again with the same values that were used on the last submission
      /// </summary>
      [JsonProperty("reuseLastSubmissionResponse")]
      public bool? reuseLastSubmissionResponse { get; set; }
    
      /// <summary>
      /// Whether its allowed to submit another response
      /// </summary>
      [JsonProperty("showSubmitAnotherResponseButton")]
      public bool? showSubmitAnotherResponseButton { get; set; }
    
      /// <summary>
      /// Text of the submit button on the public form
      /// </summary>
      [JsonProperty("submitButtonText")]
      public string submitButtonText { get; set; }
    
      /// <summary>
      /// Whether the submitter email collection is enabled
      /// </summary>
      [JsonProperty("submitterEmailCollectionEnabled")]
      public bool? submitterEmailCollectionEnabled { get; set; }
    
      /// <summary>
      /// The method to ask for the submitter email in the public form
      /// </summary>
      [JsonProperty("submitterEmailCollectionMethod")]
      public PublicFormSubmitterEmailCollectionMethod? submitterEmailCollectionMethod { get; set; }
    
      [JsonProperty("submitterEmailField")]
      public MinimalField submitterEmailField { get; set; }
    
      /// <summary>
      /// Title of the public form
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// Public form URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicFormSettings
    /// <summary>
    /// Public form fields
    /// </summary>
    public class PublicFormSettings : PublicFormInterface {
      #region members
      /// <summary>
      /// The message shown to user after submitting the public form
      /// </summary>
      [JsonProperty("afterSubmitMessage")]
      public string afterSubmitMessage { get; set; }
    
      /// <summary>
      /// The background color of the public form (RGB)
      /// </summary>
      [JsonProperty("backgroundColor")]
      public string backgroundColor { get; set; }
    
      /// <summary>
      /// The background image URL of the public form
      /// </summary>
      [JsonProperty("backgroundImage")]
      public string backgroundImage { get; set; }
    
      /// <summary>
      /// The brand color that will be used in the public form (RGB)
      /// </summary>
      [JsonProperty("brandColor")]
      public string brandColor { get; set; }
    
      /// <summary>
      /// Whether the public form creator can hide Pipefy's logo
      /// </summary>
      [JsonProperty("canHidePipefyLogo")]
      public bool? canHidePipefyLogo { get; set; }
    
      /// <summary>
      /// Public Form hCaptcha enablement flag
      /// </summary>
      [JsonProperty("captchaEnabled")]
      public bool? captchaEnabled { get; set; }
    
      /// <summary>
      /// Description of the public form
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Whether to display Pipefy's logo in the public form
      /// </summary>
      [JsonProperty("displayPipefyLogo")]
      public bool? displayPipefyLogo { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Logo of the public form
      /// </summary>
      [JsonProperty("logo")]
      public string logo { get; set; }
    
      /// <summary>
      /// The name of the organization to be shown in the public form
      /// </summary>
      [JsonProperty("organizationName")]
      public string organizationName { get; set; }
    
      /// <summary>
      /// Public form URL
      /// </summary>
      [JsonProperty("public_url")]
      public string public_url { get; set; }
    
      /// <summary>
      /// Fill again with the same values that were used on the last submission
      /// </summary>
      [JsonProperty("reuseLastSubmissionResponse")]
      public bool? reuseLastSubmissionResponse { get; set; }
    
      /// <summary>
      /// Whether its allowed to submit another response
      /// </summary>
      [JsonProperty("showSubmitAnotherResponseButton")]
      public bool? showSubmitAnotherResponseButton { get; set; }
    
      /// <summary>
      /// Text of the submit button on the public form
      /// </summary>
      [JsonProperty("submitButtonText")]
      public string submitButtonText { get; set; }
    
      /// <summary>
      /// Whether the submitter email collection is enabled
      /// </summary>
      [JsonProperty("submitterEmailCollectionEnabled")]
      public bool? submitterEmailCollectionEnabled { get; set; }
    
      /// <summary>
      /// The method to ask for the submitter email in the public form
      /// </summary>
      [JsonProperty("submitterEmailCollectionMethod")]
      public PublicFormSubmitterEmailCollectionMethod? submitterEmailCollectionMethod { get; set; }
    
      [JsonProperty("submitterEmailField")]
      public MinimalField submitterEmailField { get; set; }
    
      /// <summary>
      /// Title of the public form
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicFormSettingsInput
    /// <summary>
    /// Public form settings's inputs
    /// </summary>
    public class PublicFormSettingsInput {
      #region members
      /// <summary>
      /// The message shown to user after submitting the public form
      /// </summary>
      public string afterSubmitMessage { get; set; }
    
      /// <summary>
      /// The background color of the public form (RGB)
      /// </summary>
      public string backgroundColor { get; set; }
    
      /// <summary>
      /// The background image URL of the public form
      /// </summary>
      public string backgroundImage { get; set; }
    
      /// <summary>
      /// The brand color that will be used in the public form (RGB)
      /// </summary>
      public string brandColor { get; set; }
    
      /// <summary>
      /// Description of the public form
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// Whether to display Pipefy's logo in the public form
      /// </summary>
      public bool? displayPipefyLogo { get; set; }
    
      /// <summary>
      /// Logo of the public form
      /// </summary>
      public string logo { get; set; }
    
      /// <summary>
      /// Fill again with the same values that were used on the last submission
      /// </summary>
      public bool? reuseLastSubmissionResponse { get; set; }
    
      /// <summary>
      /// Whether its allowed to submit another response
      /// </summary>
      public bool? showSubmitAnotherResponseButton { get; set; }
    
      /// <summary>
      /// Text of the submit button on the public form
      /// </summary>
      public string submitButtonText { get; set; }
    
      /// <summary>
      /// Whether the submitter email collection is enabled
      /// </summary>
      public bool? submitterEmailCollectionEnabled { get; set; }
    
      /// <summary>
      /// The method to ask for the submitter email in the public form
      /// </summary>
      public PublicFormSubmitterEmailCollectionMethod? submitterEmailCollectionMethod { get; set; }
    
      /// <summary>
      /// The email field from which submitter email will be collected
      /// </summary>
      public string submitterEmailFieldId { get; set; }
    
      /// <summary>
      /// Title of the public form
      /// </summary>
      public string title { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
      /// <summary>
      /// The method of collecting the public form submitter email
      /// </summary>
    public enum PublicFormSubmitterEmailCollectionMethod {
      /// <summary>
      /// Collect email from an existing email field
      /// </summary>
      from_existing_email_field,
      /// <summary>
      /// Show an optional email field
      /// </summary>
      optional,
      /// <summary>
      /// Show a required email field
      /// </summary>
      required
    }
    
    
    #region PublicPhaseFormLink
    public class PublicPhaseFormLink {
      #region members
      [JsonProperty("active")]
      public bool active { get; set; }
    
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicPipe
    /// <summary>
    /// Pipe information
    /// </summary>
    public class PublicPipe : PublicRepoGQLInterface {
      #region members
      /// <summary>
      /// The creation button label
      /// </summary>
      [JsonProperty("createButtonLabel")]
      public string createButtonLabel { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// List of the pipe information.
    /// </summary>
    public interface PublicPipeInterface {
      /// <summary>
      /// Whether anyone can create cards in the pipe
      /// </summary>
      [JsonProperty("anyone_can_create_card")]
      public bool? anyone_can_create_card { get; set; }
    
      /// <summary>
      /// The pipe total cards
      /// </summary>
      [JsonProperty("cards_count")]
      public int? cards_count { get; set; }
    
      /// <summary>
      /// Information about the pipe child connections
      /// </summary>
      [JsonProperty("childrenRelations")]
      public List<PipeRelation> childrenRelations { get; set; }
    
      /// <summary>
      /// Id which the Pipe was cloned from
      /// </summary>
      [JsonProperty("clone_from_id")]
      public int? clone_from_id { get; set; }
    
      /// <summary>
      /// The content displayed in the start form button
      /// </summary>
      [JsonProperty("create_card_label")]
      public string create_card_label { get; set; }
    
      /// <summary>
      /// When the pipe was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// The pipe's email inbox address
      /// </summary>
      [JsonProperty("emailAddress")]
      public string emailAddress { get; set; }
    
      /// <summary>
      /// The number used in the pipe SLA
      /// </summary>
      [JsonProperty("expiration_time_by_unit")]
      public int? expiration_time_by_unit { get; set; }
    
      /// <summary>
      /// The seconds of the unit used in the pipe SLA
      /// </summary>
      [JsonProperty("expiration_unit")]
      public int? expiration_unit { get; set; }
    
      /// <summary>
      /// Information about the fields conditions
      /// </summary>
      [JsonProperty("fieldConditions")]
      public List<FieldCondition> fieldConditions { get; set; }
    
      /// <summary>
      /// Information about the pipe improvement setting
      /// </summary>
      [JsonProperty("improvementSetting")]
      public ImprovementSetting improvementSetting { get; set; }
    
      /// <summary>
      /// When a card was last updated in the pipe
      /// </summary>
      [JsonProperty("last_updated_by_card")]
      public any last_updated_by_card { get; set; }
    
      /// <summary>
      /// Whether only Admins can delete cards
      /// </summary>
      [JsonProperty("only_admin_can_remove_cards")]
      public bool? only_admin_can_remove_cards { get; set; }
    
      /// <summary>
      /// Whether only the card assignees can edit it
      /// </summary>
      [JsonProperty("only_assignees_can_edit_cards")]
      public bool? only_assignees_can_edit_cards { get; set; }
    
      /// <summary>
      /// Information about the pipe parent connections
      /// </summary>
      [JsonProperty("parentsRelations")]
      public List<PipeRelation> parentsRelations { get; set; }
    
      /// <summary>
      /// Information about the pipe phases
      /// </summary>
      [JsonProperty("phases")]
      public List<Phase> phases { get; set; }
    
      /// <summary>
      /// Information about the pipe preferences
      /// </summary>
      [JsonProperty("preferences")]
      public RepoPreference preferences { get; set; }
    
      /// <summary>
      /// The pipe's reports
      /// </summary>
      [JsonProperty("reports")]
      public List<PipeReport> reports { get; set; }
    
      /// <summary>
      /// Information about the start form fields conditions
      /// </summary>
      [JsonProperty("startFormFieldConditions")]
      public List<FieldCondition> startFormFieldConditions { get; set; }
    
      /// <summary>
      /// Information about the start form fields
      /// </summary>
      [JsonProperty("start_form_fields")]
      public List<PhaseField> start_form_fields { get; set; }
    
      /// <summary>
      /// The pipe Small Unique ID
      /// </summary>
      [JsonProperty("suid")]
      public string suid { get; set; }
    
      /// <summary>
      /// Information about the field selected to be the card title
      /// </summary>
      [JsonProperty("title_field")]
      public PhaseField title_field { get; set; }
    
      /// <summary>
      /// Information about the pipe users
      /// </summary>
      [JsonProperty("users")]
      public List<User> users { get; set; }
    
      /// <summary>
      /// The total users in the pipe
      /// </summary>
      [JsonProperty("users_count")]
      public int? users_count { get; set; }
    
      /// <summary>
      /// The pipe UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    
      /// <summary>
      /// Information about the pipe Webhooks
      /// </summary>
      [JsonProperty("webhooks")]
      public List<Webhook> webhooks { get; set; }
    }
    
    /// <summary>
    /// Public Repo information
    /// </summary>
    public interface PublicRepoGQLInterface {
      /// <summary>
      /// The creation button label
      /// </summary>
      [JsonProperty("createButtonLabel")]
      public string createButtonLabel { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    }
    
    #region PublicRepoItem
    /// <summary>
    /// Repo item information
    /// </summary>
    public class PublicRepoItem : PublicRepoItemInterface {
      #region members
      /// <summary>
      /// When the record was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Information about icon name and color
      /// </summary>
      [JsonProperty("icon")]
      public Icon icon { get; set; }
    
      /// <summary>
      /// The item ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The item path
      /// </summary>
      [JsonProperty("path")]
      public string path { get; set; }
    
      /// <summary>
      /// The record status
      /// </summary>
      [JsonProperty("status")]
      public TableRecordStatus status { get; set; }
    
      /// <summary>
      /// The item summary layout information
      /// </summary>
      [JsonProperty("summary")]
      public List<Summary> summary { get; set; }
    
      /// <summary>
      /// Information about the repo item attributes summary layout
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<Summary> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the repo item custom fields summary layout
      /// </summary>
      [JsonProperty("summary_fields")]
      public List<Summary> summary_fields { get; set; }
    
      /// <summary>
      /// The item title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// The URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The item uuid
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Public item information
    /// </summary>
    public interface PublicRepoItemInterface {
      /// <summary>
      /// When the record was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Information about icon name and color
      /// </summary>
      [JsonProperty("icon")]
      public Icon icon { get; set; }
    
      /// <summary>
      /// The item ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The item path
      /// </summary>
      [JsonProperty("path")]
      public string path { get; set; }
    
      /// <summary>
      /// The record status
      /// </summary>
      [JsonProperty("status")]
      public TableRecordStatus status { get; set; }
    
      /// <summary>
      /// The item summary layout information
      /// </summary>
      [JsonProperty("summary")]
      public List<Summary> summary { get; set; }
    
      /// <summary>
      /// Information about the repo item attributes summary layout
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<Summary> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the repo item custom fields summary layout
      /// </summary>
      [JsonProperty("summary_fields")]
      public List<Summary> summary_fields { get; set; }
    
      /// <summary>
      /// The item title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// The URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The item uuid
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    }
    
    #region PublicTable
    /// <summary>
    /// Table information
    /// </summary>
    public class PublicTable : PublicRepoGQLInterface {
      #region members
      /// <summary>
      /// Color of database
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// The creation button label
      /// </summary>
      [JsonProperty("createButtonLabel")]
      public string createButtonLabel { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The internal table ID
      /// </summary>
      [JsonProperty("internal_id")]
      public string internal_id { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicTableRecord
    /// <summary>
    /// Record information
    /// </summary>
    public class PublicTableRecord : PublicRepoItemInterface {
      #region members
      /// <summary>
      /// When the record was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Information about icon name and color
      /// </summary>
      [JsonProperty("icon")]
      public Icon icon { get; set; }
    
      /// <summary>
      /// The item ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The item path
      /// </summary>
      [JsonProperty("path")]
      public string path { get; set; }
    
      /// <summary>
      /// The record status
      /// </summary>
      [JsonProperty("status")]
      public TableRecordStatus status { get; set; }
    
      /// <summary>
      /// The item summary layout information
      /// </summary>
      [JsonProperty("summary")]
      public List<Summary> summary { get; set; }
    
      /// <summary>
      /// Information about the repo item attributes summary layout
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<Summary> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the repo item custom fields summary layout
      /// </summary>
      [JsonProperty("summary_fields")]
      public List<Summary> summary_fields { get; set; }
    
      /// <summary>
      /// The item title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// The URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The item uuid
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicTableRecordConnection
    /// <summary>
    /// The connection type for PublicTableRecord.
    /// </summary>
    public class PublicTableRecordConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<PublicTableRecordEdge> edges { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicTableRecordEdge
    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class PublicTableRecordEdge {
      #region members
      /// <summary>
      /// A cursor for use in pagination.
      /// </summary>
      [JsonProperty("cursor")]
      public string cursor { get; set; }
    
      /// <summary>
      /// The item at the end of the edge.
      /// </summary>
      [JsonProperty("node")]
      public PublicTableRecord node { get; set; }
      #endregion
    }
    #endregion
    
    #region PublicUser
    /// <summary>
    /// User information
    /// </summary>
    public class PublicUser {
      #region members
      /// <summary>
      /// The user's avatar URL
      /// </summary>
      [JsonProperty("avatarUrl")]
      public string avatarUrl { get; set; }
    
      /// <summary>
      /// The user's avatar URL
      /// </summary>
      [Obsolete("Use the camelCase variant (`avatarUrl`)")]
      [JsonProperty("avatar_url")]
      public string avatar_url { get; set; }
    
      /// <summary>
      /// The user email
      /// </summary>
      [JsonProperty("email")]
      public string email { get; set; }
    
      /// <summary>
      /// The user ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The user name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The user username
      /// </summary>
      [JsonProperty("username")]
      public string username { get; set; }
      #endregion
    }
    #endregion
    
    #region Query
    /// <summary>
    /// The query root of Pipefy's GraphQL interface
    /// </summary>
    public class Query {
      #region members
      /// <summary>
      /// Fetches all pipe cards based on arguments
      /// </summary>
      [JsonProperty("allCards")]
      public CardConnection allCards { get; set; }
    
      /// <summary>
      /// Lookup the values that will automatically fill the child-card's start form fields
      /// </summary>
      [JsonProperty("autoFillFields")]
      public List<AutoFillFieldUnion> autoFillFields { get; set; }
    
      /// <summary>
      /// Lookup a card by its ID
      /// </summary>
      [JsonProperty("card")]
      public Card card { get; set; }
    
      /// <summary>
      /// Fetches a group of cards based on arguments
      /// </summary>
      [JsonProperty("cards")]
      public CardConnection cards { get; set; }
    
      /// <summary>
      /// Lookup the cards importer history by the pipe ID
      /// </summary>
      [JsonProperty("cardsImportations")]
      public List<CardsImportation> cardsImportations { get; set; }
    
      [JsonProperty("conditionalField")]
      public ConditionalField conditionalField { get; set; }
    
      [JsonProperty("connectedTableRecords")]
      public PublicTableRecordConnection connectedTableRecords { get; set; }
    
      [JsonProperty("fieldCondition")]
      public FieldCondition fieldCondition { get; set; }
    
      /// <summary>
      /// Fetch cards based on fields' inputs
      /// </summary>
      [JsonProperty("findCards")]
      public CardConnection findCards { get; set; }
    
      /// <summary>
      /// Fetch records based on fields' inputs
      /// </summary>
      [JsonProperty("findRecords")]
      public CardConnection findRecords { get; set; }
    
      /// <summary>
      /// Lookup the card's emails by its ID
      /// </summary>
      [JsonProperty("inbox_emails")]
      public List<InboxEmail> inbox_emails { get; set; }
    
      /// <summary>
      /// Returns informations of the current authenticated user
      /// </summary>
      [JsonProperty("me")]
      public User me { get; set; }
    
      /// <summary>
      /// Lookup an organization by its ID
      /// </summary>
      [JsonProperty("organization")]
      public Organization organization { get; set; }
    
      /// <summary>
      /// Lookup organizations by their ID
      /// </summary>
      [JsonProperty("organizations")]
      public List<Organization> organizations { get; set; }
    
      /// <summary>
      /// Lookup a phase by its ID
      /// </summary>
      [JsonProperty("phase")]
      public Phase phase { get; set; }
    
      /// <summary>
      /// Lookup a pipe by its ID
      /// </summary>
      [JsonProperty("pipe")]
      public Pipe pipe { get; set; }
    
      /// <summary>
      /// Lookup a pipe report export by its ID
      /// </summary>
      [JsonProperty("pipeReportExport")]
      public PipeReportExport pipeReportExport { get; set; }
    
      /// <summary>
      /// Lookup pipe relations by their ID
      /// </summary>
      [JsonProperty("pipe_relations")]
      public List<PipeRelation> pipe_relations { get; set; }
    
      /// <summary>
      /// Lookup all pipe templates available on Pipefy
      /// </summary>
      [JsonProperty("pipe_templates")]
      public List<PipeTemplate> pipe_templates { get; set; }
    
      /// <summary>
      /// Lookup pipes by their ID
      /// </summary>
      [JsonProperty("pipes")]
      public List<Pipe> pipes { get; set; }
    
      /// <summary>
      /// Lookup the records importer history by the table ID
      /// </summary>
      [JsonProperty("recordsImportations")]
      public List<RecordsImportation> recordsImportations { get; set; }
    
      [JsonProperty("repoItemForm")]
      public RepoItemFormUnion repoItemForm { get; set; }
    
      /// <summary>
      /// Lookup a database table by its ID
      /// </summary>
      [JsonProperty("table")]
      public Table table { get; set; }
    
      /// <summary>
      /// Lookup a record by its ID
      /// </summary>
      [JsonProperty("table_record")]
      public TableRecord table_record { get; set; }
    
      /// <summary>
      /// Fetches a group of records based on arguments
      /// </summary>
      [JsonProperty("table_records")]
      public TableRecordWithCountConnection table_records { get; set; }
    
      /// <summary>
      /// Lookup table relations by their ID
      /// </summary>
      [JsonProperty("table_relations")]
      public List<TableRelation> table_relations { get; set; }
    
      /// <summary>
      /// Lookup database tables by their ID
      /// </summary>
      [JsonProperty("tables")]
      public List<Table> tables { get; set; }
      #endregion
    }
    #endregion
    
    #region RadioHorizontalField
    /// <summary>
    /// The horizontal radio field
    /// </summary>
    public class RadioHorizontalField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Horizontal radio field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// The horizontal radio options
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region RadioVerticalField
    /// <summary>
    /// The vertical radio field
    /// </summary>
    public class RadioVerticalField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Vertical radio field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// The vertical radio options
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region RecordsImportation
    /// <summary>
    /// Records importer information
    /// </summary>
    public class RecordsImportation : RepoItemsImportationGQLInterface {
      #region members
      /// <summary>
      /// The importation date of creation
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// The importation creator
      /// </summary>
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      /// <summary>
      /// The importation date of creation formatted
      /// </summary>
      [JsonProperty("dateFormatted")]
      public string dateFormatted { get; set; }
    
      /// <summary>
      /// The importation ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The amount of records imported
      /// </summary>
      [JsonProperty("importedRecords")]
      public int? importedRecords { get; set; }
    
      /// <summary>
      /// The importation status
      /// </summary>
      [JsonProperty("status")]
      public string status { get; set; }
    
      /// <summary>
      /// The xlsx file URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region RecordsImporterInput
    /// <summary>
    /// Autogenerated input type of RecordsImporter
    /// </summary>
    public class RecordsImporterInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Array with the field ID and its spreadsheet column with the value
      /// </summary>
      public List<FieldValuesColumnsInput> fieldValuesColumns { get; set; }
    
      /// <summary>
      /// The spreadsheet column with the record status
      /// </summary>
      public string statusColumn { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string tableId { get; set; }
    
      /// <summary>
      /// The xlsx file URL
      /// </summary>
      [JsonRequired]
      public string url { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region RecordsImporterPayload
    /// <summary>
    /// Autogenerated return type of RecordsImporter
    /// </summary>
    public class RecordsImporterPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the importation
      /// </summary>
      [JsonProperty("recordsImportation")]
      public RecordsImportation recordsImportation { get; set; }
      #endregion
    }
    #endregion
    
    #region ReferenceConnectorFieldCoreInput
    /// <summary>
    /// Connector field's inputs
    /// </summary>
    public class ReferenceConnectorFieldCoreInput {
      #region members
      /// <summary>
      /// The field UUID
      /// </summary>
      [JsonRequired]
      public string fieldUuid { get; set; }
    
      /// <summary>
      /// The next connector field ID
      /// </summary>
      public ReferenceConnectorFieldCoreInput nextConnectorField { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region ReferenceConnectorFieldInput
    /// <summary>
    /// Connector field's inputs
    /// </summary>
    public class ReferenceConnectorFieldInput {
      #region members
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string fieldId { get; set; }
    
      /// <summary>
      /// The next connector field ID
      /// </summary>
      public ReferenceConnectorFieldInput nextConnectorField { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region RemoveUserFromOrgInput
    /// <summary>
    /// Autogenerated input type of RemoveUserFromOrg
    /// </summary>
    public class RemoveUserFromOrgInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The user's email
      /// </summary>
      [JsonRequired]
      public string email { get; set; }
    
      /// <summary>
      /// The organization id
      /// </summary>
      [JsonRequired]
      public string organization_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region RemoveUserFromOrgPayload
    /// <summary>
    /// Autogenerated return type of RemoveUserFromOrg
    /// </summary>
    public class RemoveUserFromOrgPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region RemoveUserFromPipeInput
    /// <summary>
    /// Autogenerated input type of RemoveUserFromPipe
    /// </summary>
    public class RemoveUserFromPipeInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The user's email
      /// </summary>
      [JsonRequired]
      public string email { get; set; }
    
      /// <summary>
      /// The Pipe id
      /// </summary>
      public string pipe_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region RemoveUserFromPipePayload
    /// <summary>
    /// Autogenerated return type of RemoveUserFromPipe
    /// </summary>
    public class RemoveUserFromPipePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region RemoveUserFromTableInput
    /// <summary>
    /// Autogenerated input type of RemoveUserFromTable
    /// </summary>
    public class RemoveUserFromTableInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The user's email
      /// </summary>
      [JsonRequired]
      public string email { get; set; }
    
      /// <summary>
      /// The Table id
      /// </summary>
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region RemoveUserFromTablePayload
    /// <summary>
    /// Autogenerated return type of RemoveUserFromTable
    /// </summary>
    public class RemoveUserFromTablePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Repo information
    /// </summary>
    public interface Repo {
      /// <summary>
      /// Allows anyone to create cards
      /// </summary>
      [JsonProperty("anyone_can_create_card")]
      public bool? anyone_can_create_card { get; set; }
    
      /// <summary>
      /// Color of pipe/database
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// IDs of all fields in a pipe that trigger conditionals
      /// </summary>
      [JsonProperty("conditionExpressionsFieldIds")]
      public List<int?> conditionExpressionsFieldIds { get; set; }
    
      /// <summary>
      /// The Repo description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// Information about the Repo labels
      /// </summary>
      [JsonProperty("labels")]
      public List<Label> labels { get; set; }
    
      /// <summary>
      /// Information about the Repo members
      /// </summary>
      [JsonProperty("members")]
      public List<Member> members { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo noun for their registries
      /// </summary>
      [JsonProperty("noun")]
      public string noun { get; set; }
    
      /// <summary>
      /// Information about the organization
      /// </summary>
      [JsonProperty("organization")]
      public Organization organization { get; set; }
    
      /// <summary>
      /// User permissions for this repo
      /// </summary>
      [JsonProperty("permissions")]
      public RepoPermissionsInternalGQLType permissions { get; set; }
    
      /// <summary>
      /// Whether the Repo is public
      /// </summary>
      [JsonProperty("public")]
      public bool? @public { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [JsonProperty("publicForm")]
      public PublicFormInternal publicForm { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm` instead.")]
      [JsonProperty("publicFormSettings")]
      public PublicFormSettings publicFormSettings { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form")]
      public bool? public_form { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form_active")]
      public bool? public_form_active { get; set; }
    
      /// <summary>
      /// The repo start form phase id
      /// </summary>
      [JsonProperty("startFormPhaseId")]
      public string startFormPhaseId { get; set; }
    
      /// <summary>
      /// Information about the data selected to be shown in the summarized view
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<SummaryAttribute> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the Repo summary options
      /// </summary>
      [JsonProperty("summary_options")]
      public List<SummaryGroup> summary_options { get; set; }
    
      /// <summary>
      /// The total users
      /// </summary>
      [JsonProperty("users_count")]
      public int? users_count { get; set; }
    }
    
    /// <summary>
    /// Repo connection information
    /// </summary>
    public interface RepoConnection {
      /// <summary>
      /// Whether all children must be done to finish the parent
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToFinishParent")]
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all children must be done to move the parent
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToMoveParent")]
      public bool? allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether its possible to connect existing items
      /// </summary>
      [JsonProperty("canConnectExistingItems")]
      public bool? canConnectExistingItems { get; set; }
    
      /// <summary>
      /// Whether its possible to connect multiple items
      /// </summary>
      [JsonProperty("canConnectMultipleItems")]
      public bool? canConnectMultipleItems { get; set; }
    
      /// <summary>
      /// Whether its possible to create new connected items
      /// </summary>
      [JsonProperty("canCreateNewItems")]
      public bool? canCreateNewItems { get; set; }
    
      /// <summary>
      /// Information about the child Repo
      /// </summary>
      [JsonProperty("child")]
      public RepoTypes child { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonProperty("childMustExistToFinishParent")]
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Whether a child must exist to move the parent
      /// </summary>
      [JsonProperty("childMustExistToMoveParent")]
      public bool? childMustExistToMoveParent { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The relation name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Information about the parent Repo
      /// </summary>
      [JsonProperty("parent")]
      public RepoTypes parent { get; set; }
    }
    
    /// <summary>
    /// Repo item field information
    /// </summary>
    public interface RepoItemFieldGQLInterface {
      /// <summary>
      /// Repo item (Card or Record) representation
      /// </summary>
      [Obsolete("Please, use connectedRepoItems")]
      [JsonProperty("connected_repo_items")]
      public List<RepoItemTypes> connected_repo_items { get; set; }
    
      /// <summary>
      /// When the field was filled
      /// </summary>
      [JsonProperty("filled_at")]
      public any filled_at { get; set; }
    
      /// <summary>
      /// The searcheable name
      /// </summary>
      [JsonProperty("indexName")]
      public string indexName { get; set; }
    
      /// <summary>
      /// The field name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Information about the field's phase
      /// </summary>
      [JsonProperty("phase_field")]
      public PhaseField phase_field { get; set; }
    
      /// <summary>
      /// When the field was last updated
      /// </summary>
      [JsonProperty("updated_at")]
      public any updated_at { get; set; }
    }
    
    #region RepoItemFilter
    /// <summary>
    /// Options to filter cards
    /// </summary>
    public class RepoItemFilter {
      #region members
      /// <summary>
      /// Assignee to filter cards
      /// </summary>
      public List<string> cardAssigneeIds { get; set; }
    
      /// <summary>
      /// Labels to filter cards
      /// </summary>
      public List<string> cardLabelIds { get; set; }
    
      /// <summary>
      /// Text to filter cards
      /// </summary>
      public string text { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// The Repo item form
    /// </summary>
    public interface RepoItemFormGQLInterface {
      /// <summary>
      /// The available fields in Pipefy
      /// </summary>
      [JsonProperty("formFields")]
      public List<RepoItemFieldsTypes> formFields { get; set; }
    }
    
    #region RepoItemTypesConnection
    /// <summary>
    /// The connection type for RepoItemTypes.
    /// </summary>
    public class RepoItemTypesConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<RepoItemTypesEdge> edges { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region RepoItemTypesEdge
    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class RepoItemTypesEdge {
      #region members
      /// <summary>
      /// A cursor for use in pagination.
      /// </summary>
      [JsonProperty("cursor")]
      public string cursor { get; set; }
    
      /// <summary>
      /// The item at the end of the edge.
      /// </summary>
      [JsonProperty("node")]
      public RepoItemTypes node { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// Importer information
    /// </summary>
    public interface RepoItemsImportationGQLInterface {
      /// <summary>
      /// The importation date of creation
      /// </summary>
      [JsonProperty("createdAt")]
      public any createdAt { get; set; }
    
      /// <summary>
      /// The importation creator
      /// </summary>
      [JsonProperty("createdBy")]
      public User createdBy { get; set; }
    
      /// <summary>
      /// The importation date of creation formatted
      /// </summary>
      [JsonProperty("dateFormatted")]
      public string dateFormatted { get; set; }
    
      /// <summary>
      /// The importation ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The importation status
      /// </summary>
      [JsonProperty("status")]
      public string status { get; set; }
    
      /// <summary>
      /// The xlsx file URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    }
    
    #region RepoPermissionsInternalGQLType
    /// <summary>
    /// Repo permissions for the given user
    /// </summary>
    public class RepoPermissionsInternalGQLType {
      #region members
      [JsonProperty("configure_repo")]
      public bool configure_repo { get; set; }
    
      [JsonProperty("create_item")]
      public bool create_item { get; set; }
    
      [JsonProperty("delete_item")]
      public bool delete_item { get; set; }
    
      [JsonProperty("delete_repo")]
      public bool delete_repo { get; set; }
    
      [JsonProperty("manage_field")]
      public bool manage_field { get; set; }
    
      [JsonProperty("manage_label")]
      public bool manage_label { get; set; }
    
      [JsonProperty("show_repo")]
      public bool show_repo { get; set; }
      #endregion
    }
    #endregion
    
    #region RepoPreference
    /// <summary>
    /// List of all settings/preferences regarding a Repo
    /// </summary>
    public class RepoPreference {
      #region members
      /// <summary>
      /// External guests can or cannot create cards on this pipe
      /// </summary>
      [JsonProperty("enableExternalGuests")]
      public bool? enableExternalGuests { get; set; }
    
      /// <summary>
      /// Represents the attributes selected to be hidden in the start form.
      /// </summary>
      [JsonProperty("hiddenStartFormAttributes")]
      public List<string> hiddenStartFormAttributes { get; set; }
    
      /// <summary>
      /// Represents the top buttons selected to be hidden in the open card.
      /// </summary>
      [JsonProperty("hiddenTopButtons")]
      public List<string> hiddenTopButtons { get; set; }
    
      /// <summary>
      /// Whether or not the email client is enabled.
      /// </summary>
      [JsonProperty("inboxEmailEnabled")]
      public bool? inboxEmailEnabled { get; set; }
    
      /// <summary>
      /// Represents the views selected to be shown in the card.
      /// </summary>
      [JsonProperty("mainTabViews")]
      public List<string> mainTabViews { get; set; }
    
      [JsonProperty("startFormTitle")]
      public string startFormTitle { get; set; }
      #endregion
    }
    #endregion
    
    #region RepoPreferenceInput
    /// <summary>
    /// Repo preference's inputs
    /// </summary>
    public class RepoPreferenceInput {
      #region members
      /// <summary>
      /// Whether the email inbox is enable
      /// </summary>
      public bool? inboxEmailEnabled { get; set; }
    
      /// <summary>
      /// The views selected to be shown in the cards
      /// </summary>
      public List<string> mainTabViews { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region ReportCardsFilter
    /// <summary>
    /// Card search grouped queries. May contain a number of queries or other groups of queries
    /// </summary>
    public class ReportCardsFilter {
      #region members
      /// <summary>
      /// Groups that must be matched accordingly to the passed operator
      /// </summary>
      public List<ReportCardsFilter> groups { get; set; }
    
      /// <summary>
      /// Meta data used to allow tracking of each query level
      /// </summary>
      public int? id { get; set; }
    
      /// <summary>
      /// Meta data used to allow tracking of each query level
      /// </summary>
      public int? lastId { get; set; }
    
      /// <summary>
      /// The operator for this query group
      /// </summary>
      [JsonRequired]
      public ReportCardsFilterGroupOperators @operator { get; set; }
    
      /// <summary>
      /// Queries that must be matched accordingly to the passed operator
      /// </summary>
      public List<ReportCardsFilterQuery> queries { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
      /// <summary>
      /// Valid types for a field
      /// </summary>
    public enum ReportCardsFilterFieldTypes {
      /// <summary>
      /// Toggle
      /// </summary>
      boolean,
      /// <summary>
      /// Date
      /// </summary>
      date,
      /// <summary>
      /// Creator Email
      /// </summary>
      email,
      /// <summary>
      /// Grouped Select
      /// </summary>
      group_select,
      /// <summary>
      /// Number
      /// </summary>
      number,
      /// <summary>
      /// Plain Select
      /// </summary>
      select,
      /// <summary>
      /// String
      /// </summary>
      @string
    }
    
      /// <summary>
      /// Valid operators for a locally scoped group of queries
      /// </summary>
    public enum ReportCardsFilterGroupOperators {
      /// <summary>
      /// All values must match
      /// </summary>
      and,
      /// <summary>
      /// At least one value must match
      /// </summary>
      or
    }
    
    
    #region ReportCardsFilterQuery
    /// <summary>
    /// Card search query. Will match cards based on the chosen operator, field and value
    /// </summary>
    public class ReportCardsFilterQuery {
      #region members
      /// <summary>
      /// The field name
      /// </summary>
      [JsonRequired]
      public string field { get; set; }
    
      /// <summary>
      /// Meta data used to allow tracking of each query level
      /// </summary>
      public int? id { get; set; }
    
      /// <summary>
      /// The field internationalized label
      /// </summary>
      public string label { get; set; }
    
      /// <summary>
      /// The operator for this query
      /// </summary>
      [JsonRequired]
      public ReportCardsFilterQueryOperators @operator { get; set; }
    
      /// <summary>
      /// The type of the field (normally used alongside the equality operators)
      /// </summary>
      public ReportCardsFilterFieldTypes? type { get; set; }
    
      /// <summary>
      /// The value to be operated on
      /// </summary>
      public string value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
      /// <summary>
      /// Valid operators for a filter query
      /// </summary>
    public enum ReportCardsFilterQueryOperators {
      /// <summary>
      /// Contains
      /// </summary>
      contains,
      /// <summary>
      /// Equals
      /// </summary>
      eq,
      /// <summary>
      /// Exists
      /// </summary>
      exists,
      /// <summary>
      /// Greater than
      /// </summary>
      gt,
      /// <summary>
      /// Greater or equal to
      /// </summary>
      gte,
      /// <summary>
      /// Smaller than
      /// </summary>
      lt,
      /// <summary>
      /// Smaller or equal to
      /// </summary>
      lte,
      /// <summary>
      /// Not contains
      /// </summary>
      not_contains,
      /// <summary>
      /// Not equals
      /// </summary>
      not_eq,
      /// <summary>
      /// Not exists
      /// </summary>
      not_exists,
      /// <summary>
      /// Period matching value
      /// </summary>
      period,
      /// <summary>
      /// Unknown
      /// </summary>
      unknown
    }
    
    
    #region ReportSortDirection
    /// <summary>
    /// Defines how the report results are to be sorted
    /// </summary>
    public class ReportSortDirection {
      #region members
      /// <summary>
      /// The sort direction
      /// </summary>
      [JsonProperty("direction")]
      public SortDirection direction { get; set; }
    
      /// <summary>
      /// The sort field
      /// </summary>
      [JsonProperty("field")]
      public string field { get; set; }
      #endregion
    }
    #endregion
    
    #region ReportSortDirectionInput
    /// <summary>
    /// Defines how the report results are to be sorted
    /// </summary>
    public class ReportSortDirectionInput {
      #region members
      /// <summary>
      /// The sort direction
      /// </summary>
      [JsonRequired]
      public SortDirection direction { get; set; }
    
      /// <summary>
      /// The sort field
      /// </summary>
      [JsonRequired]
      public string field { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region Role
    /// <summary>
    /// List of role information
    /// </summary>
    public class Role {
      #region members
      /// <summary>
      /// Role created date
      /// </summary>
      [JsonProperty("created_by")]
      public string created_by { get; set; }
    
      /// <summary>
      /// Role description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// Role id
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// If Role is custom
      /// </summary>
      [JsonProperty("isCustom")]
      public bool? isCustom { get; set; }
    
      /// <summary>
      /// Number of users in this role
      /// </summary>
      [JsonProperty("memberCount")]
      public int? memberCount { get; set; }
    
      /// <summary>
      /// Role name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Role tile
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// Role last update
      /// </summary>
      [JsonProperty("updated_by")]
      public string updated_by { get; set; }
    
      /// <summary>
      /// Role UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region SelectField
    /// <summary>
    /// The select field
    /// </summary>
    public class SelectField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Select field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// The select options
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region SendInboxEmailInput
    /// <summary>
    /// Autogenerated input type of SendInboxEmail
    /// </summary>
    public class SendInboxEmailInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The email ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SendInboxEmailPayload
    /// <summary>
    /// Autogenerated return type of SendInboxEmail
    /// </summary>
    public class SendInboxEmailPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region SetDismissedImprovementInput
    /// <summary>
    /// Autogenerated input type of SetDismissedImprovement
    /// </summary>
    public class SetDismissedImprovementInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      [JsonRequired]
      public string id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SetDismissedImprovementPayload
    /// <summary>
    /// Autogenerated return type of SetDismissedImprovement
    /// </summary>
    public class SetDismissedImprovementPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region SetImprovementAsReadInput
    /// <summary>
    /// Autogenerated input type of SetImprovementAsRead
    /// </summary>
    public class SetImprovementAsReadInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      [JsonRequired]
      public string improvementSettingId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SetImprovementAsReadPayload
    /// <summary>
    /// Autogenerated return type of SetImprovementAsRead
    /// </summary>
    public class SetImprovementAsReadPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region SetRoleInput
    /// <summary>
    /// Autogenerated input type of SetRole
    /// </summary>
    public class SetRoleInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The member information
      /// </summary>
      [JsonRequired]
      public MemberInput member { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      public string organization_id { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      public string pipe_id { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SetRolePayload
    /// <summary>
    /// Autogenerated return type of SetRole
    /// </summary>
    public class SetRolePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the member
      /// </summary>
      [JsonProperty("member")]
      public Member member { get; set; }
      #endregion
    }
    #endregion
    
    #region SetRolesInput
    /// <summary>
    /// Autogenerated input type of SetRoles
    /// </summary>
    public class SetRolesInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Array with the user ID and role name
      /// </summary>
      [JsonRequired]
      public List<MemberInput> members { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      public string organization_id { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      public string pipe_id { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SetRolesPayload
    /// <summary>
    /// Autogenerated return type of SetRoles
    /// </summary>
    public class SetRolesPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns possible errors in the mutation
      /// </summary>
      [JsonProperty("errors")]
      public List<string> errors { get; set; }
    
      /// <summary>
      /// Returns information about the members
      /// </summary>
      [JsonProperty("members")]
      public List<Member> members { get; set; }
      #endregion
    }
    #endregion
    
    #region SetSummaryAttributesInput
    /// <summary>
    /// Autogenerated input type of SetSummaryAttributes
    /// </summary>
    public class SetSummaryAttributesInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      public string pipe_id { get; set; }
    
      /// <summary>
      /// The fields ID
      /// 
      /// Standard options:
      /// - id
      /// - title
      /// - current_phase
      /// - labels
      /// - due_date
      /// - created_by
      /// - assignees
      /// - finished_at
      /// - created_at
      /// - updated_at
      /// - last_comment
      /// - las_comment_at
      /// </summary>
      [JsonRequired]
      public List<string> summary_attributes { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SetSummaryAttributesPayload
    /// <summary>
    /// Autogenerated return type of SetSummaryAttributes
    /// </summary>
    public class SetSummaryAttributesPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the summary attributes
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<SummaryAttribute> summary_attributes { get; set; }
      #endregion
    }
    #endregion
    
    #region SetTableFieldOrderInput
    /// <summary>
    /// Autogenerated input type of SetTableFieldOrder
    /// </summary>
    public class SetTableFieldOrderInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The fields ID in order
      /// </summary>
      [JsonRequired]
      public List<string> field_ids { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string table_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SetTableFieldOrderPayload
    /// <summary>
    /// Autogenerated return type of SetTableFieldOrder
    /// </summary>
    public class SetTableFieldOrderPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the table fields
      /// </summary>
      [JsonProperty("table_fields")]
      public List<TableField> table_fields { get; set; }
      #endregion
    }
    #endregion
    
    #region SetTableRecordFieldValueInput
    /// <summary>
    /// Autogenerated input type of SetTableRecordFieldValue
    /// </summary>
    public class SetTableRecordFieldValueInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string field_id { get; set; }
    
      /// <summary>
      /// The record ID
      /// </summary>
      [JsonRequired]
      public string table_record_id { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      public List<any> value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region SetTableRecordFieldValuePayload
    /// <summary>
    /// Autogenerated return type of SetTableRecordFieldValue
    /// </summary>
    public class SetTableRecordFieldValuePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the record
      /// </summary>
      [JsonProperty("table_record")]
      public TableRecord table_record { get; set; }
    
      /// <summary>
      /// Returns information about the record field
      /// </summary>
      [JsonProperty("table_record_field")]
      public TableRecordField table_record_field { get; set; }
      #endregion
    }
    #endregion
    
    #region ShortTextField
    /// <summary>
    /// The short text field
    /// </summary>
    public class ShortTextField : FieldType {
      #region members
      /// <summary>
      /// The short text field custom validation
      /// </summary>
      [JsonProperty("customValidation")]
      public string customValidation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Short text field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
      /// <summary>
      /// The direction of the sorting
      /// </summary>
    public enum SortDirection {
      /// <summary>
      /// Ascendant
      /// </summary>
      asc,
      /// <summary>
      /// Descendant
      /// </summary>
      desc
    }
    
    
    #region StatementField
    /// <summary>
    /// The statement field
    /// </summary>
    public class StatementField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region Summary
    /// <summary>
    /// List of the summary informations.
    /// </summary>
    public class Summary {
      #region members
      /// <summary>
      /// Represents the raw unformatted value of the selected field to be represented in the summary.
      /// </summary>
      [JsonProperty("raw_value")]
      public string raw_value { get; set; }
    
      /// <summary>
      /// Represents the title of the selected field to be represented in the summary.
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// Field type
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Represents the value of the selected field to be represented in the summary.
      /// </summary>
      [JsonProperty("value")]
      public string value { get; set; }
      #endregion
    }
    #endregion
    
    #region SummaryAttribute
    /// <summary>
    /// List of the summary attributes information.
    /// </summary>
    public class SummaryAttribute {
      #region members
      /// <summary>
      /// Represents summary attribute identifier. It accepts the field's internal identifier or the repository attribute's slug.
      /// 
      /// Valid repository attribute's options:
      /// - id
      /// - title
      /// - current_phase
      /// - labels
      /// - due_date
      /// - created_by
      /// - assignees
      /// - finished_at
      /// - created_at
      /// - status
      /// - updated_at
      /// - last_comment
      /// - last_comment_at
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
      #endregion
    }
    #endregion
    
    #region SummaryGroup
    /// <summary>
    /// List of the summary group information.
    /// </summary>
    public class SummaryGroup {
      #region members
      /// <summary>
      /// Represents a general information of a card or a phase's field.
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Lookup the summary group options by its identifier.
      /// </summary>
      [JsonProperty("options")]
      public List<SummaryOption> options { get; set; }
      #endregion
    }
    #endregion
    
    #region SummaryOption
    /// <summary>
    /// List of the summary option information.
    /// </summary>
    public class SummaryOption {
      #region members
      /// <summary>
      /// Represents the field's internal identifier or the card attribute's slug.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the summary option title label.
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
      #endregion
    }
    #endregion
    
    #region Table
    /// <summary>
    /// List of table information
    /// </summary>
    public class Table : Repo {
      #region members
      /// <summary>
      /// Allows anyone to create cards
      /// </summary>
      [JsonProperty("anyone_can_create_card")]
      public bool? anyone_can_create_card { get; set; }
    
      /// <summary>
      /// Information about the database table authorization
      /// </summary>
      [JsonProperty("authorization")]
      public TableAuthorization? authorization { get; set; }
    
      /// <summary>
      /// Color of pipe/database
      /// </summary>
      [JsonProperty("color")]
      public string color { get; set; }
    
      /// <summary>
      /// IDs of all fields in a pipe that trigger conditionals
      /// </summary>
      [JsonProperty("conditionExpressionsFieldIds")]
      public List<int?> conditionExpressionsFieldIds { get; set; }
    
      /// <summary>
      /// The content displayed in the start form button
      /// </summary>
      [JsonProperty("create_record_button_label")]
      public string create_record_button_label { get; set; }
    
      /// <summary>
      /// The Repo description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      /// <summary>
      /// The database table ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The database table internal ID
      /// </summary>
      [JsonProperty("internal_id")]
      public string internal_id { get; set; }
    
      /// <summary>
      /// Information about the Repo labels
      /// </summary>
      [JsonProperty("labels")]
      public List<Label> labels { get; set; }
    
      /// <summary>
      /// Information about the Repo members
      /// </summary>
      [JsonProperty("members")]
      public List<Member> members { get; set; }
    
      /// <summary>
      /// Information about the current user permission
      /// </summary>
      [JsonProperty("my_permissions")]
      public TablePermission my_permissions { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo noun for their registries
      /// </summary>
      [JsonProperty("noun")]
      public string noun { get; set; }
    
      /// <summary>
      /// The orderable fields. Valid options: title, status, created_at, updated_at, finished_at
      /// </summary>
      [JsonProperty("orderableFields")]
      public List<string> orderableFields { get; set; }
    
      /// <summary>
      /// The orderable field types
      /// </summary>
      [JsonProperty("orderableTypes")]
      public List<string> orderableTypes { get; set; }
    
      /// <summary>
      /// Information about the organization
      /// </summary>
      [JsonProperty("organization")]
      public Organization organization { get; set; }
    
      /// <summary>
      /// User permissions for this repo
      /// </summary>
      [JsonProperty("permissions")]
      public RepoPermissionsInternalGQLType permissions { get; set; }
    
      /// <summary>
      /// Whether the Repo is public
      /// </summary>
      [JsonProperty("public")]
      public bool? @public { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [JsonProperty("publicForm")]
      public PublicFormInternal publicForm { get; set; }
    
      /// <summary>
      /// Information about the public form settings
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm` instead.")]
      [JsonProperty("publicFormSettings")]
      public PublicFormSettings publicFormSettings { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form")]
      public bool? public_form { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      [Obsolete("This field is deprecated. Use `publicForm { active }` instead.")]
      [JsonProperty("public_form_active")]
      public bool? public_form_active { get; set; }
    
      /// <summary>
      /// The repo start form phase id
      /// </summary>
      [JsonProperty("startFormPhaseId")]
      public string startFormPhaseId { get; set; }
    
      /// <summary>
      /// Information about the database table statuses
      /// </summary>
      [JsonProperty("statuses")]
      public List<TableRecordStatus> statuses { get; set; }
    
      /// <summary>
      /// Information about the data selected to be shown in the summarized view
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<SummaryAttribute> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the Repo summary options
      /// </summary>
      [JsonProperty("summary_options")]
      public List<SummaryGroup> summary_options { get; set; }
    
      /// <summary>
      /// Information about the database table fields
      /// </summary>
      [JsonProperty("table_fields")]
      public List<TableField> table_fields { get; set; }
    
      /// <summary>
      /// Fetches a group of records based on arguments
      /// </summary>
      [JsonProperty("table_records")]
      public TableRecordConnection table_records { get; set; }
    
      /// <summary>
      /// The database table total records
      /// </summary>
      [JsonProperty("table_records_count")]
      public int? table_records_count { get; set; }
    
      /// <summary>
      /// Information about the field selected to be the record title
      /// </summary>
      [JsonProperty("title_field")]
      public TableField title_field { get; set; }
    
      /// <summary>
      /// The database table URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The total users
      /// </summary>
      [JsonProperty("users_count")]
      public int? users_count { get; set; }
    
      /// <summary>
      /// The database uuid
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    
      /// <summary>
      /// Information about the table Webhooks
      /// </summary>
      [JsonProperty("webhooks")]
      public List<Webhook> webhooks { get; set; }
      #endregion
    }
    #endregion
      /// <summary>
      /// The table authorization options
      /// </summary>
    public enum TableAuthorization {
      /// <summary>
      /// User can only view the records
      /// </summary>
      read,
      /// <summary>
      /// User can add, edit and remove records
      /// </summary>
      write
    }
    
    
    #region TableConnection
    /// <summary>
    /// The connection type for Table.
    /// </summary>
    public class TableConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<TableEdge> edges { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region TableEdge
    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class TableEdge {
      #region members
      /// <summary>
      /// A cursor for use in pagination.
      /// </summary>
      [JsonProperty("cursor")]
      public string cursor { get; set; }
    
      /// <summary>
      /// The item at the end of the edge.
      /// </summary>
      [JsonProperty("node")]
      public Table node { get; set; }
      #endregion
    }
    #endregion
    
    #region TableField
    /// <summary>
    /// List of table field information
    /// </summary>
    public class TableField : GenericField, MinimalFieldInterface {
      #region members
      /// <summary>
      /// Whether all child items must be done to finish the parent item
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToFinishParent")]
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether it's possible to connect existing items
      /// </summary>
      [JsonProperty("canConnectExisting")]
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Whether it's possible to connect multiple items
      /// </summary>
      [JsonProperty("canConnectMultiples")]
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Whether its possible to create new connected items
      /// </summary>
      [JsonProperty("canCreateNewConnected")]
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonProperty("childMustExistToFinishParent")]
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Repo (Pipe or Table) representation
      /// </summary>
      [JsonProperty("connectedRepo")]
      public PublicRepoUnion connectedRepo { get; set; }
    
      /// <summary>
      /// Repo (Pipe or Table) representation
      /// </summary>
      [Obsolete("connected_repo has been replaced by connectedRepo")]
      [JsonProperty("connected_repo")]
      public RepoTypes connected_repo { get; set; }
    
      /// <summary>
      /// The regex used to validate the field value
      /// </summary>
      [JsonProperty("custom_validation")]
      public string custom_validation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("help")]
      public string help { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// field index
      /// </summary>
      [JsonProperty("index")]
      public float? index { get; set; }
    
      /// <summary>
      /// field index name
      /// </summary>
      [JsonProperty("index_name")]
      public string index_name { get; set; }
    
      /// <summary>
      /// The field internal ID
      /// </summary>
      [JsonProperty("internal_id")]
      public string internal_id { get; set; }
    
      /// <summary>
      /// Whether the field accepts multiple entries
      /// </summary>
      [JsonProperty("is_multiple")]
      public bool? is_multiple { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimal_view")]
      public bool? minimal_view { get; set; }
    
      /// <summary>
      /// The options of the Checklist, Radio or Select field
      /// </summary>
      [JsonProperty("options")]
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("required")]
      public bool? required { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time, formula, dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field must have a unique value
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field Universally Unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region TablePermission
    /// <summary>
    /// List of the database table managing permissions.
    /// </summary>
    public class TablePermission {
      #region members
      /// <summary>
      /// Whether or not user can create, edit and delete records in the database table.
      /// </summary>
      [JsonProperty("can_manage_record")]
      public bool? can_manage_record { get; set; }
    
      /// <summary>
      /// Whether or not user can edit and delete the database table (Admin).
      /// </summary>
      [JsonProperty("can_manage_table")]
      public bool? can_manage_table { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecord
    /// <summary>
    /// List of table record information
    /// </summary>
    public class TableRecord {
      #region members
      /// <summary>
      /// Information about the assign users
      /// </summary>
      [JsonProperty("assignees")]
      public List<User> assignees { get; set; }
    
      /// <summary>
      /// When the record was created
      /// </summary>
      [JsonProperty("created_at")]
      public any created_at { get; set; }
    
      /// <summary>
      /// Information about the record creator
      /// </summary>
      [JsonProperty("created_by")]
      public User created_by { get; set; }
    
      /// <summary>
      /// Whether the record is done
      /// </summary>
      [JsonProperty("done")]
      public bool? done { get; set; }
    
      /// <summary>
      /// The record due date
      /// </summary>
      [JsonProperty("due_date")]
      public any due_date { get; set; }
    
      /// <summary>
      /// When the record was finished
      /// </summary>
      [JsonProperty("finished_at")]
      public any finished_at { get; set; }
    
      /// <summary>
      /// The record ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Informs if a record is a sample record
      /// </summary>
      [JsonProperty("is_sample")]
      public bool? is_sample { get; set; }
    
      /// <summary>
      /// Information about the record labels
      /// </summary>
      [JsonProperty("labels")]
      public List<Label> labels { get; set; }
    
      /// <summary>
      /// Information about the parent table connections
      /// </summary>
      [JsonProperty("parent_relations")]
      public List<TableRecordRelation> parent_relations { get; set; }
    
      /// <summary>
      /// The record path
      /// </summary>
      [JsonProperty("path")]
      public string path { get; set; }
    
      /// <summary>
      /// Information about the record fields
      /// </summary>
      [JsonProperty("record_fields")]
      public List<TableRecordField> record_fields { get; set; }
    
      /// <summary>
      /// The record status
      /// </summary>
      [JsonProperty("status")]
      public TableRecordStatus status { get; set; }
    
      /// <summary>
      /// Information about the record summary layout
      /// </summary>
      [JsonProperty("summary")]
      public List<Summary> summary { get; set; }
    
      /// <summary>
      /// Information about the card attributes summary layout
      /// </summary>
      [JsonProperty("summary_attributes")]
      public List<Summary> summary_attributes { get; set; }
    
      /// <summary>
      /// Information about the card custom fields summary layout
      /// </summary>
      [JsonProperty("summary_fields")]
      public List<Summary> summary_fields { get; set; }
    
      /// <summary>
      /// Information about the database table
      /// </summary>
      [JsonProperty("table")]
      public Table table { get; set; }
    
      /// <summary>
      /// The record title
      /// </summary>
      [JsonProperty("title")]
      public string title { get; set; }
    
      /// <summary>
      /// When the record was last updated
      /// </summary>
      [JsonProperty("updated_at")]
      public any updated_at { get; set; }
    
      /// <summary>
      /// The URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
    
      /// <summary>
      /// The record uuid
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecordConnection
    /// <summary>
    /// The connection type for TableRecord.
    /// </summary>
    public class TableRecordConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<TableRecordEdge> edges { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecordEdge
    /// <summary>
    /// An edge in a connection.
    /// </summary>
    public class TableRecordEdge {
      #region members
      /// <summary>
      /// A cursor for use in pagination.
      /// </summary>
      [JsonProperty("cursor")]
      public string cursor { get; set; }
    
      /// <summary>
      /// The item at the end of the edge.
      /// </summary>
      [JsonProperty("node")]
      public TableRecord node { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecordField
    /// <summary>
    /// Lookup all record fields information.
    /// </summary>
    public class TableRecordField : MinimalCardFieldValueInterface, RepoItemFieldGQLInterface {
      #region members
      /// <summary>
      /// The value of an Attachment, Checklists, Connection or Label field, processed as an array type
      /// </summary>
      [JsonProperty("array_value")]
      public List<string> array_value { get; set; }
    
      /// <summary>
      /// Information about the users assigned to the card
      /// </summary>
      [JsonProperty("assignee_values")]
      public List<User> assignee_values { get; set; }
    
      /// <summary>
      /// Information about cards and records connected with the card
      /// </summary>
      [JsonProperty("connectedRepoItems")]
      public List<PublicRepoItemTypes> connectedRepoItems { get; set; }
    
      /// <summary>
      /// Repo item (Card or Record) representation
      /// </summary>
      [Obsolete("Please, use connectedRepoItems")]
      [JsonProperty("connected_repo_items")]
      public List<RepoItemTypes> connected_repo_items { get; set; }
    
      /// <summary>
      /// The value of a Date, DateTime or DueDate field, processed as a date type
      /// </summary>
      [JsonProperty("date_value")]
      public DateTime date_value { get; set; }
    
      /// <summary>
      /// The value of a DateTime or DueDate field, processed as a date and time type
      /// </summary>
      [JsonProperty("datetime_value")]
      public any datetime_value { get; set; }
    
      /// <summary>
      /// Information about the card field
      /// </summary>
      [JsonProperty("field")]
      public MinimalField field { get; set; }
    
      /// <summary>
      /// When the field was filled
      /// </summary>
      [JsonProperty("filled_at")]
      public any filled_at { get; set; }
    
      /// <summary>
      /// The field float value
      /// </summary>
      [JsonProperty("float_value")]
      public float? float_value { get; set; }
    
      /// <summary>
      /// The searcheable name
      /// </summary>
      [JsonProperty("indexName")]
      public string indexName { get; set; }
    
      /// <summary>
      /// Information about the card label
      /// </summary>
      [JsonProperty("label_values")]
      public List<FieldLabel> label_values { get; set; }
    
      /// <summary>
      /// The field name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The field value for show
      /// </summary>
      [JsonProperty("native_value")]
      public string native_value { get; set; }
    
      /// <summary>
      /// Information about the field's phase
      /// </summary>
      [JsonProperty("phase_field")]
      public PhaseField phase_field { get; set; }
    
      /// <summary>
      /// The field value prepared for report
      /// </summary>
      [JsonProperty("report_value")]
      public string report_value { get; set; }
    
      /// <summary>
      /// Whether or not the record's field is required.
      /// </summary>
      [JsonProperty("required")]
      public bool? required { get; set; }
    
      /// <summary>
      /// When the field was last updated
      /// </summary>
      [JsonProperty("updated_at")]
      public any updated_at { get; set; }
    
      /// <summary>
      /// The field value
      /// </summary>
      [JsonProperty("value")]
      public string value { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecordForm
    /// <summary>
    /// translation missing: en.api.documentation.table_record_form.description
    /// </summary>
    public class TableRecordForm : PublicRepoGQLInterface, RepoItemFormGQLInterface {
      #region members
      /// <summary>
      /// The creation button label
      /// </summary>
      [JsonProperty("createButtonLabel")]
      public string createButtonLabel { get; set; }
    
      /// <summary>
      /// The available fields in Pipefy
      /// </summary>
      [JsonProperty("formFields")]
      public List<RepoItemFieldsTypes> formFields { get; set; }
    
      /// <summary>
      /// The Repo icon
      /// </summary>
      [JsonProperty("icon")]
      public string icon { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The Repo name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The Repo UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecordRelation
    /// <summary>
    /// List of the database table record's relations information.
    /// </summary>
    public class TableRecordRelation {
      #region members
      /// <summary>
      /// Represents a relation's id.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents a relation's name.
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Represents a repo (Card or Table Record).
      /// </summary>
      [JsonProperty("repo")]
      public TableConnectedRepoGQLCoreUnionTypes repo { get; set; }
    
      /// <summary>
      /// Fetches a group of records based on arguments.
      /// </summary>
      [JsonProperty("repo_items")]
      public RepoItemTypesConnection repo_items { get; set; }
    
      /// <summary>
      /// Represents the type source. It can be a database table or a pipe.
      /// </summary>
      [JsonProperty("source_type")]
      public string source_type { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecordSearch
    /// <summary>
    /// Records search's inputs
    /// </summary>
    public class TableRecordSearch {
      #region members
      /// <summary>
      /// The assignee ID
      /// </summary>
      public List<string> assignee_ids { get; set; }
    
      /// <summary>
      /// The records ID to be ignored
      /// </summary>
      public List<string> ignore_ids { get; set; }
    
      /// <summary>
      /// Shows or not done records
      /// </summary>
      public bool? include_done { get; set; }
    
      /// <summary>
      /// The label ID
      /// </summary>
      public List<string> label_ids { get; set; }
    
      /// <summary>
      /// The sort direction
      /// 
      /// Valid options:
      /// - asc
      /// - desc
      /// </summary>
      public string orderDirection { get; set; }
    
      /// <summary>
      /// The field used to sort results
      /// </summary>
      public string orderField { get; set; }
    
      /// <summary>
      /// The record title
      /// </summary>
      public string title { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region TableRecordStatus
    /// <summary>
    /// List of the record status information.
    /// </summary>
    public class TableRecordStatus {
      #region members
      /// <summary>
      /// Represents the status identifier.
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Represents the status name.
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRecordWithCountConnection
    /// <summary>
    /// The connection type for TableRecord.
    /// </summary>
    public class TableRecordWithCountConnection {
      #region members
      /// <summary>
      /// A list of edges.
      /// </summary>
      [JsonProperty("edges")]
      public List<TableRecordEdge> edges { get; set; }
    
      /// <summary>
      /// The amount of records in the table
      /// </summary>
      [JsonProperty("matchCount")]
      public int? matchCount { get; set; }
    
      /// <summary>
      /// Information to aid in pagination.
      /// </summary>
      [JsonProperty("pageInfo")]
      public PageInfo pageInfo { get; set; }
      #endregion
    }
    #endregion
    
    #region TableRelation
    /// <summary>
    /// List of the table's relation information.
    /// </summary>
    public class TableRelation : RepoConnection {
      #region members
      /// <summary>
      /// Whether all children must be done to finish the parent
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToFinishParent")]
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all children must be done to move the parent
      /// </summary>
      [JsonProperty("allChildrenMustBeDoneToMoveParent")]
      public bool? allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether its possible to connect existing items
      /// </summary>
      [JsonProperty("canConnectExistingItems")]
      public bool? canConnectExistingItems { get; set; }
    
      /// <summary>
      /// Whether its possible to connect multiple items
      /// </summary>
      [JsonProperty("canConnectMultipleItems")]
      public bool? canConnectMultipleItems { get; set; }
    
      /// <summary>
      /// Whether its possible to create new connected items
      /// </summary>
      [JsonProperty("canCreateNewItems")]
      public bool? canCreateNewItems { get; set; }
    
      /// <summary>
      /// Information about the child Repo
      /// </summary>
      [JsonProperty("child")]
      public RepoTypes child { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonProperty("childMustExistToFinishParent")]
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Whether a child must exist to move the parent
      /// </summary>
      [JsonProperty("childMustExistToMoveParent")]
      public bool? childMustExistToMoveParent { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The relation name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Information about the parent Repo
      /// </summary>
      [JsonProperty("parent")]
      public RepoTypes parent { get; set; }
      #endregion
    }
    #endregion
    
    #region TimeField
    /// <summary>
    /// The time field
    /// </summary>
    public class TimeField : FieldType {
      #region members
      /// <summary>
      /// The field description
      /// </summary>
      [JsonProperty("description")]
      public string description { get; set; }
    
      /// <summary>
      /// The field current state
      /// </summary>
      [JsonProperty("displayState")]
      public ConditionFieldActions? displayState { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      [JsonProperty("helpText")]
      public string helpText { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [Obsolete("Please, use uuid")]
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Time field initial value
      /// </summary>
      [JsonProperty("initialValue")]
      public string initialValue { get; set; }
    
      /// <summary>
      /// If the field could be editable
      /// </summary>
      [JsonProperty("isEditable")]
      public bool? isEditable { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      [JsonProperty("isRequired")]
      public bool? isRequired { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonProperty("label")]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      [JsonProperty("minimalView")]
      public bool? minimalView { get; set; }
    
      /// <summary>
      /// Whether the field triggers a condition
      /// </summary>
      [JsonProperty("triggersFieldConditions")]
      public bool? triggersFieldConditions { get; set; }
    
      /// <summary>
      /// The field type. Valid options: assignee_select, attachment, checklist_horizontal, checklist_vertical, cnpj, connector, cpf, currency, date, datetime, due_date, email, id, label_select, long_text, number, phone, radio_horizontal, radio_vertical, select, short_text, statement, time,dynamic_content
      /// </summary>
      [JsonProperty("type")]
      public string type { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      [JsonProperty("unique")]
      public bool? unique { get; set; }
    
      /// <summary>
      /// The field universally unique ID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateCardFieldInput
    /// <summary>
    /// Autogenerated input type of UpdateCardField
    /// </summary>
    public class UpdateCardFieldInput {
      #region members
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonRequired]
      public string card_id { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string field_id { get; set; }
    
      /// <summary>
      /// Field new value
      /// </summary>
      public List<any> new_value { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateCardFieldPayload
    /// <summary>
    /// Autogenerated return type of UpdateCardField
    /// </summary>
    public class UpdateCardFieldPayload {
      #region members
      /// <summary>
      /// Returns information about the card
      /// </summary>
      [JsonProperty("card")]
      public Card card { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Whether the mutation was successful
      /// </summary>
      [JsonProperty("success")]
      public bool? success { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateCardInput
    /// <summary>
    /// Autogenerated input type of UpdateCard
    /// </summary>
    public class UpdateCardInput {
      #region members
      /// <summary>
      /// The assignee IDs
      /// </summary>
      public List<string> assignee_ids { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The card due date
      /// </summary>
      public any due_date { get; set; }
    
      /// <summary>
      /// The card ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The label ID
      /// </summary>
      public List<string> label_ids { get; set; }
    
      /// <summary>
      /// The card title
      /// </summary>
      public string title { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateCardPayload
    /// <summary>
    /// Autogenerated return type of UpdateCard
    /// </summary>
    public class UpdateCardPayload {
      #region members
      /// <summary>
      /// Returns information about the card
      /// </summary>
      [JsonProperty("card")]
      public Card card { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateCommentInput
    /// <summary>
    /// Autogenerated input type of UpdateComment
    /// </summary>
    public class UpdateCommentInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The comment ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The comment text
      /// </summary>
      [JsonRequired]
      public string text { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateCommentPayload
    /// <summary>
    /// Autogenerated return type of UpdateComment
    /// </summary>
    public class UpdateCommentPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the comment
      /// </summary>
      [JsonProperty("comment")]
      public Comment comment { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateFieldConditionInput
    /// <summary>
    /// Autogenerated input type of UpdateFieldCondition
    /// </summary>
    public class UpdateFieldConditionInput {
      #region members
      /// <summary>
      /// Array with field condition's actions
      /// </summary>
      public List<FieldConditionActionInput> actions { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The field condition's condition
      /// </summary>
      public ConditionInput condition { get; set; }
    
      /// <summary>
      /// The field condition ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The field condition name
      /// </summary>
      public string name { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      public string phase_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateFieldConditionPayload
    /// <summary>
    /// Autogenerated return type of UpdateFieldCondition
    /// </summary>
    public class UpdateFieldConditionPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the fieldCondition
      /// </summary>
      [JsonProperty("fieldCondition")]
      public FieldCondition fieldCondition { get; set; }
      #endregion
    }
    #endregion
      /// <summary>
      /// Set the operation for the update field value.
      /// </summary>
    public enum UpdateFieldValuesOperators {
      /// <summary>
      /// Append values to existing list of values, compatible with field types that support lists like Attachments, Assignees, Labels, Connections and Checklists.
      /// </summary>
      ADD,
      /// <summary>
      /// Remove values from the existing list of values, compatible with field types that support lists like Attachments, Assignees, Labels, Connections and Checklists.
      /// </summary>
      REMOVE,
      /// <summary>
      /// Replace the existing value with the new one provided.
      /// </summary>
      REPLACE
    }
    
    
    #region UpdateFieldsValuesInput
    /// <summary>
    /// Autogenerated input type of UpdateFieldsValues
    /// </summary>
    public class UpdateFieldsValuesInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The card or table record ID that will be updated.
      /// </summary>
      [JsonRequired]
      public string nodeId { get; set; }
    
      /// <summary>
      /// Array of fields that you want to update with the value and operation. Limit of 30 fields per call.
      /// </summary>
      [JsonRequired]
      public List<NodeFieldValueInput> values { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateFieldsValuesPayload
    /// <summary>
    /// Autogenerated return type of UpdateFieldsValues
    /// </summary>
    public class UpdateFieldsValuesPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Return if the mutation ran succesfully or not.
      /// </summary>
      [JsonProperty("success")]
      public bool success { get; set; }
    
      /// <summary>
      /// The updated card or table record.
      /// </summary>
      [JsonProperty("updatedNode")]
      public UpdatedNode updatedNode { get; set; }
    
      /// <summary>
      /// List of errors that occurred executing the mutation.
      /// </summary>
      [JsonProperty("userErrors")]
      public List<UserError> userErrors { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateLabelInput
    /// <summary>
    /// Autogenerated input type of UpdateLabel
    /// </summary>
    public class UpdateLabelInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The label color (hexadecimal)
      /// </summary>
      [JsonRequired]
      public string color { get; set; }
    
      /// <summary>
      /// The label ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The label name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateLabelPayload
    /// <summary>
    /// Autogenerated return type of UpdateLabel
    /// </summary>
    public class UpdateLabelPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the label
      /// </summary>
      [JsonProperty("label")]
      public Label label { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateOrganizationInput
    /// <summary>
    /// Autogenerated input type of UpdateOrganization
    /// </summary>
    public class UpdateOrganizationInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The organization ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The organization name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// Whether the creation of new pipes is restricted to the organization Admin
      /// </summary>
      public bool? only_admin_can_create_pipes { get; set; }
    
      /// <summary>
      /// Whether the invitation of new users is restricted to the organization Admin
      /// </summary>
      public bool? only_admin_can_invite_users { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateOrganizationPayload
    /// <summary>
    /// Autogenerated return type of UpdateOrganization
    /// </summary>
    public class UpdateOrganizationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the organization
      /// </summary>
      [JsonProperty("organization")]
      public Organization organization { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateOrganizationWebhookInput
    /// <summary>
    /// Autogenerated input type of UpdateOrganizationWebhook
    /// </summary>
    public class UpdateOrganizationWebhookInput {
      #region members
      /// <summary>
      /// The webhook trigger
      /// 
      /// Valid options:
      /// - user.invitation_sent
      /// - user.invitation_acceptance
      /// - user.removal_from_org
      /// - user.role_set
      /// </summary>
      public List<string> actions { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The webhook's notification email
      /// </summary>
      public string email { get; set; }
    
      /// <summary>
      /// The webhook's custom headers
      /// </summary>
      public any headers { get; set; }
    
      /// <summary>
      /// The webhook ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The webhook's name
      /// </summary>
      public string name { get; set; }
    
      /// <summary>
      /// The webhook's notification URL
      /// </summary>
      public string url { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateOrganizationWebhookPayload
    /// <summary>
    /// Autogenerated return type of UpdateOrganizationWebhook
    /// </summary>
    public class UpdateOrganizationWebhookPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the webhook
      /// </summary>
      [JsonProperty("webhook")]
      public Webhook webhook { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdatePhaseFieldInput
    /// <summary>
    /// Autogenerated input type of UpdatePhaseField
    /// </summary>
    public class UpdatePhaseFieldInput {
      #region members
      /// <summary>
      /// Connection Field: Whether all children must be done to finish the parent
      /// </summary>
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Connection Field: Whether all children must be done to move the parent
      /// </summary>
      public bool? allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Connection Field: Whether can connect with existing items
      /// </summary>
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to connect with multiple items
      /// </summary>
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to create new connected items
      /// </summary>
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Connection Field: Whether a child must exist to finish the parent
      /// </summary>
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The regex used to validate the field's value
      /// </summary>
      public string custom_validation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// Whether the field is editable
      /// </summary>
      public bool? editable { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      public string help { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The new field index
      /// </summary>
      public float? index { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      [JsonRequired]
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      public bool? minimal_view { get; set; }
    
      /// <summary>
      /// The field options
      /// </summary>
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      public bool? required { get; set; }
    
      /// <summary>
      /// Whether the field is sync with the fixed field
      /// </summary>
      public bool? sync_with_card { get; set; }
    
      /// <summary>
      /// The field UUID
      /// </summary>
      public string uuid { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdatePhaseFieldPayload
    /// <summary>
    /// Autogenerated return type of UpdatePhaseField
    /// </summary>
    public class UpdatePhaseFieldPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the phase field
      /// </summary>
      [JsonProperty("phase_field")]
      public PhaseField phase_field { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdatePhaseInput
    /// <summary>
    /// Autogenerated input type of UpdatePhase
    /// </summary>
    public class UpdatePhaseInput {
      #region members
      /// <summary>
      /// Whether cards can be created directly in the phase
      /// </summary>
      public bool? can_receive_card_directly_from_draft { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The phase color
      /// </summary>
      public Colors? color { get; set; }
    
      /// <summary>
      /// The phase description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// Whether it's a final phase
      /// </summary>
      public bool? done { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The phase's SLA in seconds
      /// </summary>
      public int? lateness_time { get; set; }
    
      /// <summary>
      /// The phase name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// ARGUMENT IS DEPRECATED!
      /// </summary>
      public bool? only_admin_can_move_to_previous { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdatePhasePayload
    /// <summary>
    /// Autogenerated return type of UpdatePhase
    /// </summary>
    public class UpdatePhasePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the phase
      /// </summary>
      [JsonProperty("phase")]
      public Phase phase { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdatePipeInput
    /// <summary>
    /// Autogenerated input type of UpdatePipe
    /// </summary>
    public class UpdatePipeInput {
      #region members
      /// <summary>
      /// Whether all organization members can create cards in the pipe
      /// </summary>
      public bool? anyone_can_create_card { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Color of pipe
      /// </summary>
      public Colors? color { get; set; }
    
      /// <summary>
      /// The pipe's SLA unit
      /// </summary>
      public int? expiration_time_by_unit { get; set; }
    
      /// <summary>
      /// The pipe's SLA expiration period
      /// 
      /// - Minutes: 60
      /// - Hours: 3600
      /// - Day: 86400
      /// </summary>
      public int? expiration_unit { get; set; }
    
      /// <summary>
      /// The pipe icon
      /// 
      /// Valid options:
      /// - airplane
      /// - at
      /// - axe
      /// - badge
      /// - bag
      /// - boat
      /// - briefing
      /// - bug
      /// - bullhorn
      /// - calendar
      /// - cart
      /// - cat
      /// - chart-zoom
      /// - chart2
      /// - chat
      /// - check
      /// - checklist
      /// - compass
      /// - contract
      /// - dog
      /// - eiffel
      /// - emo
      /// - finish-flag
      /// - flame
      /// - frame
      /// - frog
      /// - game
      /// - github
      /// - globe
      /// - growth
      /// - hr-process
      /// - hr-requests
      /// - ice
      /// - juice
      /// - lamp
      /// - lemonade
      /// - liberty
      /// - like
      /// - mac
      /// - magic
      /// - map
      /// - message
      /// - mkt-requests
      /// - money
      /// - onboarding
      /// - pacman
      /// - pacman1
      /// - payable
      /// - phone
      /// - pipefy
      /// - pizza
      /// - planet
      /// - plug
      /// - receivables
      /// - receive
      /// - recruitment-requests
      /// - reload
      /// - rocket
      /// - sales
      /// - skull
      /// - snow-flake
      /// - star
      /// - target
      /// - task
      /// - task-management
      /// - trophy
      /// - underwear
      /// </summary>
      public string icon { get; set; }
    
      /// <summary>
      /// The pipe ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The pipe name
      /// </summary>
      public string name { get; set; }
    
      /// <summary>
      /// Noun for pipe registries
      /// </summary>
      public string noun { get; set; }
    
      /// <summary>
      /// Whether only the Admin can delete cards
      /// </summary>
      public bool? only_admin_can_remove_cards { get; set; }
    
      /// <summary>
      /// Whether only assignee can edit the card
      /// </summary>
      public bool? only_assignees_can_edit_cards { get; set; }
    
      /// <summary>
      /// The pipe preferences
      /// </summary>
      public RepoPreferenceInput preferences { get; set; }
    
      /// <summary>
      /// Whether the pipe is public
      /// </summary>
      public bool? @public { get; set; }
    
      /// <summary>
      /// Public form settings
      /// </summary>
      public PublicFormSettingsInput publicFormSettings { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      public bool? public_form { get; set; }
    
      /// <summary>
      /// The title field ID
      /// </summary>
      public string title_field_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdatePipePayload
    /// <summary>
    /// Autogenerated return type of UpdatePipe
    /// </summary>
    public class UpdatePipePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the pipe
      /// </summary>
      [JsonProperty("pipe")]
      public Pipe pipe { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdatePipeRelationInput
    /// <summary>
    /// Autogenerated input type of UpdatePipeRelation
    /// </summary>
    public class UpdatePipeRelationInput {
      #region members
      /// <summary>
      /// Whether all children must be done to finish the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all children must be done to move the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether the relation has auto fill active
      /// </summary>
      [JsonRequired]
      public bool autoFillFieldEnabled { get; set; }
    
      /// <summary>
      /// Whether can connect with existing items
      /// </summary>
      [JsonRequired]
      public bool canConnectExistingItems { get; set; }
    
      /// <summary>
      /// Whether is possible to connect with multiple items
      /// </summary>
      [JsonRequired]
      public bool canConnectMultipleItems { get; set; }
    
      /// <summary>
      /// Whether is possible to create new connected items
      /// </summary>
      [JsonRequired]
      public bool canCreateNewItems { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Whether a child must exist to move the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToMoveParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The relation name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
    
      /// <summary>
      /// Array of field input to be used in the auto fill
      /// </summary>
      public List<FieldMapInput> ownFieldMaps { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdatePipeRelationPayload
    /// <summary>
    /// Autogenerated return type of UpdatePipeRelation
    /// </summary>
    public class UpdatePipeRelationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the pipe relation
      /// </summary>
      [JsonProperty("pipeRelation")]
      public PipeRelation pipeRelation { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateTableFieldInput
    /// <summary>
    /// Autogenerated input type of UpdateTableField
    /// </summary>
    public class UpdateTableFieldInput {
      #region members
      /// <summary>
      /// Connection Field: Whether all children must be done to finish the parent
      /// </summary>
      public bool? allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Connection Field: Whether can connect with existing items
      /// </summary>
      public bool? canConnectExisting { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to connect with multiple items
      /// </summary>
      public bool? canConnectMultiples { get; set; }
    
      /// <summary>
      /// Connection Field: Whether is possible to create new connected items
      /// </summary>
      public bool? canCreateNewConnected { get; set; }
    
      /// <summary>
      /// Connection Field: Whether a child must exist to finish the parent
      /// </summary>
      public bool? childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The regex used to validate the field's value
      /// </summary>
      public string custom_validation { get; set; }
    
      /// <summary>
      /// The field description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// The field help text
      /// </summary>
      public string help { get; set; }
    
      /// <summary>
      /// The field ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The field title
      /// </summary>
      public string label { get; set; }
    
      /// <summary>
      /// Whether the field is minimal
      /// </summary>
      public bool? minimal_view { get; set; }
    
      /// <summary>
      /// The field options
      /// </summary>
      public List<string> options { get; set; }
    
      /// <summary>
      /// Whether the field is required
      /// </summary>
      public bool? required { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string table_id { get; set; }
    
      /// <summary>
      /// Whether the field value must be unique
      /// </summary>
      public bool? unique { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateTableFieldPayload
    /// <summary>
    /// Autogenerated return type of UpdateTableField
    /// </summary>
    public class UpdateTableFieldPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the table fields
      /// </summary>
      [JsonProperty("table_field")]
      public TableField table_field { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateTableInput
    /// <summary>
    /// Autogenerated input type of UpdateTable
    /// </summary>
    public class UpdateTableInput {
      #region members
      /// <summary>
      /// The table authorization
      /// 
      /// Valid options:
      /// - read
      /// - write
      /// </summary>
      public TableAuthorization? authorization { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Color of database
      /// </summary>
      public Colors? color { get; set; }
    
      /// <summary>
      /// The create record button text
      /// </summary>
      public string create_record_button_label { get; set; }
    
      /// <summary>
      /// The table description
      /// </summary>
      public string description { get; set; }
    
      /// <summary>
      /// The table icon
      /// 
      /// Valid options:
      /// - airplane
      /// - at
      /// - axe
      /// - badge
      /// - bag
      /// - boat
      /// - briefing
      /// - bug
      /// - bullhorn
      /// - calendar
      /// - cart
      /// - cat
      /// - chart-zoom
      /// - chart2
      /// - chat
      /// - check
      /// - checklist
      /// - compass
      /// - contract
      /// - dog
      /// - eiffel
      /// - emo
      /// - finish-flag
      /// - flame
      /// - frame
      /// - frog
      /// - game
      /// - github
      /// - globe
      /// - growth
      /// - hr-process
      /// - hr-requests
      /// - ice
      /// - juice
      /// - lamp
      /// - lemonade
      /// - liberty
      /// - like
      /// - mac
      /// - magic
      /// - map
      /// - message
      /// - mkt-requests
      /// - money
      /// - onboarding
      /// - pacman
      /// - pacman1
      /// - payable
      /// - phone
      /// - pipefy
      /// - pizza
      /// - planet
      /// - plug
      /// - receivables
      /// - receive
      /// - recruitment-requests
      /// - reload
      /// - rocket
      /// - sales
      /// - skull
      /// - snow-flake
      /// - star
      /// - target
      /// - task
      /// - task-management
      /// - trophy
      /// - underwear
      /// </summary>
      public string icon { get; set; }
    
      /// <summary>
      /// The table ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The table name
      /// </summary>
      public string name { get; set; }
    
      /// <summary>
      /// Noun for database registries
      /// </summary>
      public string noun { get; set; }
    
      /// <summary>
      /// Whether the table is public
      /// </summary>
      public bool? @public { get; set; }
    
      /// <summary>
      /// Public form settings
      /// </summary>
      public PublicFormSettingsInput publicFormSettings { get; set; }
    
      /// <summary>
      /// Whether the public form is active
      /// </summary>
      public bool? public_form { get; set; }
    
      /// <summary>
      /// Array with fields ID
      /// </summary>
      public List<string> summary_attributes { get; set; }
    
      /// <summary>
      /// The title field ID
      /// </summary>
      public string title_field_id { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateTablePayload
    /// <summary>
    /// Autogenerated return type of UpdateTable
    /// </summary>
    public class UpdateTablePayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the table
      /// </summary>
      [JsonProperty("table")]
      public Table table { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateTableRecordInput
    /// <summary>
    /// Autogenerated input type of UpdateTableRecord
    /// </summary>
    public class UpdateTableRecordInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The record due date
      /// </summary>
      public any due_date { get; set; }
    
      /// <summary>
      /// The record ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The record status
      /// </summary>
      public string statusId { get; set; }
    
      /// <summary>
      /// The record title
      /// </summary>
      public string title { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateTableRecordPayload
    /// <summary>
    /// Autogenerated return type of UpdateTableRecord
    /// </summary>
    public class UpdateTableRecordPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the record
      /// </summary>
      [JsonProperty("table_record")]
      public TableRecord table_record { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateTableRelationInput
    /// <summary>
    /// Autogenerated input type of UpdateTableRelation
    /// </summary>
    public class UpdateTableRelationInput {
      #region members
      /// <summary>
      /// Whether all children must be done to finish the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToFinishParent { get; set; }
    
      /// <summary>
      /// Whether all children must be done to move the parent
      /// </summary>
      [JsonRequired]
      public bool allChildrenMustBeDoneToMoveParent { get; set; }
    
      /// <summary>
      /// Whether can connect with existing items
      /// </summary>
      [JsonRequired]
      public bool canConnectExistingItems { get; set; }
    
      /// <summary>
      /// Whether is possible to connect with multiple items
      /// </summary>
      [JsonRequired]
      public bool canConnectMultipleItems { get; set; }
    
      /// <summary>
      /// Whether is possible to create new connected items
      /// </summary>
      [JsonRequired]
      public bool canCreateNewItems { get; set; }
    
      /// <summary>
      /// Whether a child must exist to finish the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToFinishParent { get; set; }
    
      /// <summary>
      /// Whether a child must exist to move the parent
      /// </summary>
      [JsonRequired]
      public bool childMustExistToMoveParent { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The relation ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The relation name
      /// </summary>
      [JsonRequired]
      public string name { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateTableRelationPayload
    /// <summary>
    /// Autogenerated return type of UpdateTableRelation
    /// </summary>
    public class UpdateTableRelationPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the table relation
      /// </summary>
      [JsonProperty("tableRelation")]
      public TableRelation tableRelation { get; set; }
      #endregion
    }
    #endregion
    
    #region UpdateWebhookInput
    /// <summary>
    /// Autogenerated input type of UpdateWebhook
    /// </summary>
    public class UpdateWebhookInput {
      #region members
      /// <summary>
      /// The webhook's trigger(s)
      /// 
      /// Valid options:
      /// - card.create
      /// - card.done
      /// - card.expired
      /// - card.late
      /// - card.move
      /// - card.overdue
      /// - card.field_update
      /// - card.delete
      /// </summary>
      public List<string> actions { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The webhook's notification email
      /// </summary>
      public string email { get; set; }
    
      /// <summary>
      /// The webhook's custom headers
      /// </summary>
      public any headers { get; set; }
    
      /// <summary>
      /// The webhook ID
      /// </summary>
      [JsonRequired]
      public string id { get; set; }
    
      /// <summary>
      /// The webhook's name
      /// </summary>
      public string name { get; set; }
    
      /// <summary>
      /// The webhook's notification URL
      /// </summary>
      public string url { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region UpdateWebhookPayload
    /// <summary>
    /// Autogenerated return type of UpdateWebhook
    /// </summary>
    public class UpdateWebhookPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the webhook
      /// </summary>
      [JsonProperty("webhook")]
      public Webhook webhook { get; set; }
      #endregion
    }
    #endregion
    
    #region User
    /// <summary>
    /// List of user information
    /// </summary>
    public class User : UserInterface {
      #region members
      /// <summary>
      /// The user avatar URL
      /// </summary>
      [JsonProperty("avatarUrl")]
      public string avatarUrl { get; set; }
    
      /// <summary>
      /// The user avatar URL
      /// </summary>
      [Obsolete("avatar_url has been replaced by avatarUrl")]
      [JsonProperty("avatar_url")]
      public string avatar_url { get; set; }
    
      /// <summary>
      /// Whether the user confirmation token expired and is no longer valid
      /// </summary>
      [JsonProperty("confirmationTokenHasExpired")]
      public bool confirmationTokenHasExpired { get; set; }
    
      /// <summary>
      /// Whether the user is confirmed or not
      /// </summary>
      [JsonProperty("confirmed")]
      public bool confirmed { get; set; }
    
      /// <summary>
      /// When the user was created
      /// </summary>
      [JsonProperty("createdAt")]
      public string createdAt { get; set; }
    
      /// <summary>
      /// When the user was created
      /// </summary>
      [Obsolete("This field is deprecated. Use `createdAt` instead.")]
      [JsonProperty("created_at")]
      public string created_at { get; set; }
    
      /// <summary>
      /// The user department key
      /// </summary>
      [JsonProperty("departmentKey")]
      public string departmentKey { get; set; }
    
      /// <summary>
      /// The user display name
      /// </summary>
      [JsonProperty("displayName")]
      public string displayName { get; set; }
    
      /// <summary>
      /// The user email
      /// </summary>
      [JsonProperty("email")]
      public string email { get; set; }
    
      /// <summary>
      /// Returns if the user has unread notifications
      /// </summary>
      [JsonProperty("hasUnreadNotifications")]
      public bool? hasUnreadNotifications { get; set; }
    
      /// <summary>
      /// The user ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Return the hash reference for intercom
      /// </summary>
      [JsonProperty("intercomHash")]
      public string intercomHash { get; set; }
    
      /// <summary>
      /// The user intercom reference
      /// </summary>
      [JsonProperty("intercomId")]
      public string intercomId { get; set; }
    
      /// <summary>
      /// Whether the user was invited to register or not
      /// </summary>
      [JsonProperty("invited")]
      public bool invited { get; set; }
    
      /// <summary>
      /// The user language
      /// </summary>
      [JsonProperty("locale")]
      public string locale { get; set; }
    
      /// <summary>
      /// The user name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Current user permission to this user
      /// </summary>
      [JsonProperty("permissions")]
      public UserPermissionsInternalGqlType permissions { get; set; }
    
      /// <summary>
      /// The user's phone
      /// </summary>
      [JsonProperty("phone")]
      public string phone { get; set; }
    
      /// <summary>
      /// The user preferences
      /// </summary>
      [JsonProperty("preferences")]
      public UserPreference preferences { get; set; }
    
      /// <summary>
      /// The user template category key
      /// </summary>
      [JsonProperty("signupData")]
      public string signupData { get; set; }
    
      /// <summary>
      /// The user time zone
      /// </summary>
      [Obsolete("This field is deprecated. Use `timezone` instead")]
      [JsonProperty("timeZone")]
      public string timeZone { get; set; }
    
      /// <summary>
      /// The user time zone
      /// </summary>
      [Obsolete("This field is deprecated. Use `timezone` instead")]
      [JsonProperty("time_zone")]
      public string time_zone { get; set; }
    
      /// <summary>
      /// The user time zone
      /// </summary>
      [JsonProperty("timezone")]
      public string timezone { get; set; }
    
      /// <summary>
      /// The user username
      /// </summary>
      [JsonProperty("username")]
      public string username { get; set; }
    
      /// <summary>
      /// The user UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
      #endregion
    }
    #endregion
    
    #region UserError
    /// <summary>
    /// Represents an error in the input of a mutation.
    /// </summary>
    public class UserError {
      #region members
      /// <summary>
      /// Path to the input field which caused the error.
      /// </summary>
      [JsonProperty("field")]
      public List<string> field { get; set; }
    
      /// <summary>
      /// The error message.
      /// </summary>
      [JsonProperty("message")]
      public string message { get; set; }
      #endregion
    }
    #endregion
    
    /// <summary>
    /// List of user information
    /// </summary>
    public interface UserInterface {
      /// <summary>
      /// The user avatar URL
      /// </summary>
      [JsonProperty("avatarUrl")]
      public string avatarUrl { get; set; }
    
      /// <summary>
      /// The user avatar URL
      /// </summary>
      [Obsolete("avatar_url has been replaced by avatarUrl")]
      [JsonProperty("avatar_url")]
      public string avatar_url { get; set; }
    
      /// <summary>
      /// Whether the user is confirmed or not
      /// </summary>
      [JsonProperty("confirmed")]
      public bool confirmed { get; set; }
    
      /// <summary>
      /// When the user was created
      /// </summary>
      [JsonProperty("createdAt")]
      public string createdAt { get; set; }
    
      /// <summary>
      /// When the user was created
      /// </summary>
      [Obsolete("This field is deprecated. Use `createdAt` instead.")]
      [JsonProperty("created_at")]
      public string created_at { get; set; }
    
      /// <summary>
      /// The user department key
      /// </summary>
      [JsonProperty("departmentKey")]
      public string departmentKey { get; set; }
    
      /// <summary>
      /// The user display name
      /// </summary>
      [JsonProperty("displayName")]
      public string displayName { get; set; }
    
      /// <summary>
      /// The user email
      /// </summary>
      [JsonProperty("email")]
      public string email { get; set; }
    
      /// <summary>
      /// Returns if the user has unread notifications
      /// </summary>
      [JsonProperty("hasUnreadNotifications")]
      public bool? hasUnreadNotifications { get; set; }
    
      /// <summary>
      /// The user ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// Return the hash reference for intercom
      /// </summary>
      [JsonProperty("intercomHash")]
      public string intercomHash { get; set; }
    
      /// <summary>
      /// The user intercom reference
      /// </summary>
      [JsonProperty("intercomId")]
      public string intercomId { get; set; }
    
      /// <summary>
      /// Whether the user was invited to register or not
      /// </summary>
      [JsonProperty("invited")]
      public bool invited { get; set; }
    
      /// <summary>
      /// The user language
      /// </summary>
      [JsonProperty("locale")]
      public string locale { get; set; }
    
      /// <summary>
      /// The user name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// Current user permission to this user
      /// </summary>
      [JsonProperty("permissions")]
      public UserPermissionsInternalGqlType permissions { get; set; }
    
      /// <summary>
      /// The user's phone
      /// </summary>
      [JsonProperty("phone")]
      public string phone { get; set; }
    
      /// <summary>
      /// The user preferences
      /// </summary>
      [JsonProperty("preferences")]
      public UserPreference preferences { get; set; }
    
      /// <summary>
      /// The user template category key
      /// </summary>
      [JsonProperty("signupData")]
      public string signupData { get; set; }
    
      /// <summary>
      /// The user time zone
      /// </summary>
      [Obsolete("This field is deprecated. Use `timezone` instead")]
      [JsonProperty("timeZone")]
      public string timeZone { get; set; }
    
      /// <summary>
      /// The user time zone
      /// </summary>
      [Obsolete("This field is deprecated. Use `timezone` instead")]
      [JsonProperty("time_zone")]
      public string time_zone { get; set; }
    
      /// <summary>
      /// The user time zone
      /// </summary>
      [JsonProperty("timezone")]
      public string timezone { get; set; }
    
      /// <summary>
      /// The user username
      /// </summary>
      [JsonProperty("username")]
      public string username { get; set; }
    
      /// <summary>
      /// The user UUID
      /// </summary>
      [JsonProperty("uuid")]
      public string uuid { get; set; }
    }
    
    #region UserPermissionsInternalGqlType
    /// <summary>
    /// User permissions based on current user session
    /// </summary>
    public class UserPermissionsInternalGqlType {
      #region members
      [JsonProperty("canChangeToCompanyGuestInAdminPortal")]
      public bool canChangeToCompanyGuestInAdminPortal { get; set; }
      #endregion
    }
    #endregion
    
    #region UserPreference
    /// <summary>
    /// List of user preferences information.
    /// </summary>
    public class UserPreference {
      #region members
      /// <summary>
      /// Whether the user notification is enable or not
      /// </summary>
      [JsonProperty("browserNativeNotificationEnabled")]
      public bool? browserNativeNotificationEnabled { get; set; }
    
      /// <summary>
      /// Whether the improvements are visible or not
      /// </summary>
      [JsonProperty("displayImprovements")]
      public bool? displayImprovements { get; set; }
    
      /// <summary>
      /// Represents organization reports sidebar status (hide or show) of an user.
      /// </summary>
      [JsonProperty("displayOrganizationReportSidebar")]
      public bool? displayOrganizationReportSidebar { get; set; }
    
      /// <summary>
      /// Whether the Pipe Reports Sidebar is visible or not
      /// </summary>
      [JsonProperty("displayPipeReportsSidebar")]
      public bool? displayPipeReportsSidebar { get; set; }
    
      /// <summary>
      /// List of pipes (by id) favourited by the user
      /// </summary>
      [JsonProperty("favoritePipeIds")]
      public List<int?> favoritePipeIds { get; set; }
    
      /// <summary>
      /// Whether the startform open in a modal or inside open card
      /// </summary>
      [JsonProperty("openNestedStartForm")]
      public bool? openNestedStartForm { get; set; }
    
      /// <summary>
      /// Whether the sidebar is opened or not
      /// </summary>
      [JsonProperty("sidebarOpened")]
      public bool? sidebarOpened { get; set; }
    
      /// <summary>
      /// Whether the user closed the suggested templates box
      /// </summary>
      [JsonProperty("suggestedTemplatesClosed")]
      public bool? suggestedTemplatesClosed { get; set; }
      #endregion
    }
    #endregion
    
    #region Webhook
    /// <summary>
    /// List of webhook information
    /// </summary>
    public class Webhook {
      #region members
      /// <summary>
      /// The webhook triggers. Valid options: card.create, card.done, card.expired, card.late, card.move, card.overdue, card.field_update, card.delete, user.removal_from_org, user.removal_from_pipe, user.removal_from_table, user.role_set, user.invitation_acceptance, user.invitation_sent
      /// </summary>
      [JsonProperty("actions")]
      public List<string> actions { get; set; }
    
      /// <summary>
      /// The webhook chosen email
      /// </summary>
      [JsonProperty("email")]
      public string email { get; set; }
    
      /// <summary>
      /// The webhook custom headers in a valid JSON format. Example: {"Custom-Header": "value"}
      /// </summary>
      [JsonProperty("headers")]
      public any headers { get; set; }
    
      /// <summary>
      /// The webhook ID
      /// </summary>
      [JsonProperty("id")]
      public string id { get; set; }
    
      /// <summary>
      /// The webhook name
      /// </summary>
      [JsonProperty("name")]
      public string name { get; set; }
    
      /// <summary>
      /// The webhook URL
      /// </summary>
      [JsonProperty("url")]
      public string url { get; set; }
      #endregion
    }
    #endregion
    
    #region cardLateness
    public class cardLateness {
      #region members
      [JsonProperty("becameLateAt")]
      public any becameLateAt { get; set; }
    
      [JsonProperty("id")]
      public string id { get; set; }
    
      [JsonProperty("shouldBecomeLateAt")]
      public any shouldBecomeLateAt { get; set; }
    
      [JsonProperty("sla")]
      public int sla { get; set; }
      #endregion
    }
    #endregion
    
    #region ConfigurePublicPhaseFormLinkInput
    /// <summary>
    /// Autogenerated input type of configurePublicPhaseFormLink
    /// </summary>
    public class ConfigurePublicPhaseFormLinkInput {
      #region members
      [JsonRequired]
      public string cardId { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      [JsonRequired]
      public bool enable { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region CreateFieldConditionInput
    /// <summary>
    /// Autogenerated input type of createFieldCondition
    /// </summary>
    public class CreateFieldConditionInput {
      #region members
      /// <summary>
      /// Array with field condition's actions
      /// </summary>
      public List<FieldConditionActionInput> actions { get; set; }
    
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// The field condition's condition
      /// </summary>
      public ConditionInput condition { get; set; }
    
      /// <summary>
      /// The condition position
      /// </summary>
      public float? index { get; set; }
    
      /// <summary>
      /// The field condition name
      /// </summary>
      public string name { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      public string phaseId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region createFieldConditionPayload
    /// <summary>
    /// Autogenerated return type of createFieldCondition
    /// </summary>
    public class createFieldConditionPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the fieldCondition
      /// </summary>
      [JsonProperty("fieldCondition")]
      public FieldCondition fieldCondition { get; set; }
      #endregion
    }
    #endregion
    
    #region SetFieldConditionOrderInput
    /// <summary>
    /// Autogenerated input type of setFieldConditionOrder
    /// </summary>
    public class SetFieldConditionOrderInput {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Array of field condition IDs
      /// </summary>
      [JsonRequired]
      public List<string> fieldConditionIds { get; set; }
    
      /// <summary>
      /// The phase ID
      /// </summary>
      [JsonRequired]
      public string phaseId { get; set; }
      #endregion
    
      #region methods
      public dynamic GetInputObject()
      {
        IDictionary<string, object> d = new System.Dynamic.ExpandoObject();
    
        var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
        foreach (var propertyInfo in properties)
        {
          var value = propertyInfo.GetValue(this);
          var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;
    
          var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
          if (requiredProp || value != defaultValue)
          {
            d[propertyInfo.Name] = value;
          }
        }
        return d;
      }
      #endregion
    }
    #endregion
    
    #region setFieldConditionOrderPayload
    /// <summary>
    /// Autogenerated return type of setFieldConditionOrder
    /// </summary>
    public class setFieldConditionOrderPayload {
      #region members
      /// <summary>
      /// A unique identifier for the client performing the mutation.
      /// </summary>
      [JsonProperty("clientMutationId")]
      public string clientMutationId { get; set; }
    
      /// <summary>
      /// Returns information about the fieldCondition
      /// </summary>
      [JsonProperty("fieldConditions")]
      public List<FieldCondition> fieldConditions { get; set; }
      #endregion
    }
    #endregion
  }
  
}
