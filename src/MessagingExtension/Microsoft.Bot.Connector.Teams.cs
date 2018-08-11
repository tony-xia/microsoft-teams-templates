// The source code in this file is copied from https://github.com/OfficeDev/BotBuilder-MicrosoftTeams
// because the package "Microsoft.Bot.Connector.Teams" v0.9.0 does not support .NET Standard at the moment.
// When "Microsoft.Bot.Connector.Teams" is ready in future, the code in this file is not needed.

namespace Microsoft.Bot.Connector.Teams.Models
{
    using System.Linq;
    using Microsoft.Bot.Schema;

    /// <summary>
    /// Compose extension attachment.
    /// </summary>
    public partial class ComposeExtensionAttachment : Attachment
    {
        /// <summary>
        /// Initializes a new instance of the ComposeExtensionAttachment class.
        /// </summary>
        public ComposeExtensionAttachment() { }

        /// <summary>
        /// Initializes a new instance of the ComposeExtensionAttachment class.
        /// </summary>
        /// <param name="contentType">mimetype/Contenttype for the file</param>
        /// <param name="contentUrl">Content Url</param>
        /// <param name="content">Embedded content</param>
        /// <param name="name">(OPTIONAL) The name of the attachment</param>
        /// <param name="thumbnailUrl">(OPTIONAL) Thumbnail associated with
        /// attachment</param>
        /// <param name="preview">Specifies how the result should be displayed
        /// in the preview window</param>
        public ComposeExtensionAttachment(string contentType = default(string), string contentUrl = default(string), object content = default(object), string name = default(string), string thumbnailUrl = default(string), Attachment preview = default(Attachment))
            : base(contentType, contentUrl, content, name, thumbnailUrl)
        {
            Preview = preview;
        }

        /// <summary>
        /// Gets or sets specifies how the result should be displayed in the
        /// preview window
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "preview")]
        public Attachment Preview { get; set; }

    }

    /// <summary>
    /// Compose extension query parameters
    /// </summary>
    public partial class ComposeExtensionParameter
    {
        /// <summary>
        /// Initializes a new instance of the ComposeExtensionParameter class.
        /// </summary>
        public ComposeExtensionParameter() { }

        /// <summary>
        /// Initializes a new instance of the ComposeExtensionParameter class.
        /// </summary>
        /// <param name="name">Name of the parameter</param>
        /// <param name="value">Value of the parameter</param>
        public ComposeExtensionParameter(string name = default(string), object value = default(object))
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets name of the parameter
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets value of the parameter
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

    }

    /// <summary>
    /// Compose extension query
    /// </summary>
    public partial class ComposeExtensionQuery
    {
        /// <summary>
        /// Initializes a new instance of the ComposeExtensionQuery class.
        /// </summary>
        public ComposeExtensionQuery() { }

        /// <summary>
        /// Initializes a new instance of the ComposeExtensionQuery class.
        /// </summary>
        /// <param name="commandId">Id of the command assigned by Bot</param>
        /// <param name="parameters">Parameters for the query</param>
        /// <param name="queryOptions">Options for the query</param>
        /// <param name="state">State parameter passed back to the bot after
        /// authentication/configuration flow</param>
        public ComposeExtensionQuery(string commandId = default(string), System.Collections.Generic.IList<ComposeExtensionParameter> parameters = default(System.Collections.Generic.IList<ComposeExtensionParameter>), ComposeExtensionQueryOptions queryOptions = default(ComposeExtensionQueryOptions), string state = default(string))
        {
            CommandId = commandId;
            Parameters = parameters;
            QueryOptions = queryOptions;
            State = state;
        }

        /// <summary>
        /// Gets or sets id of the command assigned by Bot
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "commandId")]
        public string CommandId { get; set; }

        /// <summary>
        /// Gets or sets parameters for the query
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "parameters")]
        public System.Collections.Generic.IList<ComposeExtensionParameter> Parameters { get; set; }

        /// <summary>
        /// Gets or sets options for the query
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "queryOptions")]
        public ComposeExtensionQueryOptions QueryOptions { get; set; }

        /// <summary>
        /// Gets or sets state parameter passed back to the bot after
        /// authentication/configuration flow
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "state")]
        public string State { get; set; }

    }

    /// <summary>
    /// Compose extensions query options
    /// </summary>
    public partial class ComposeExtensionQueryOptions
    {
        /// <summary>
        /// Initializes a new instance of the ComposeExtensionQueryOptions
        /// class.
        /// </summary>
        public ComposeExtensionQueryOptions() { }

        /// <summary>
        /// Initializes a new instance of the ComposeExtensionQueryOptions
        /// class.
        /// </summary>
        /// <param name="skip">Number of entities to skip</param>
        /// <param name="count">Number of entities to fetch</param>
        public ComposeExtensionQueryOptions(int? skip = default(int?), int? count = default(int?))
        {
            Skip = skip;
            Count = count;
        }

        /// <summary>
        /// Gets or sets number of entities to skip
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "skip")]
        public int? Skip { get; set; }

        /// <summary>
        /// Gets or sets number of entities to fetch
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }

    }


    /// <summary>
    /// Compose extension response
    /// </summary>
    public partial class ComposeExtensionResponse
    {
        /// <summary>
        /// Initializes a new instance of the ComposeExtensionResponse class.
        /// </summary>
        public ComposeExtensionResponse() { }

        /// <summary>
        /// Initializes a new instance of the ComposeExtensionResponse class.
        /// </summary>
        public ComposeExtensionResponse(ComposeExtensionResult composeExtension = default(ComposeExtensionResult))
        {
            ComposeExtension = composeExtension;
        }

        /// <summary>
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "composeExtension")]
        public ComposeExtensionResult ComposeExtension { get; set; }

    }


    /// <summary>
    /// Compose extension result
    /// </summary>
    public partial class ComposeExtensionResult
    {
        /// <summary>
        /// Initializes a new instance of the ComposeExtensionResult class.
        /// </summary>
        public ComposeExtensionResult() { }

        /// <summary>
        /// Initializes a new instance of the ComposeExtensionResult class.
        /// </summary>
        /// <param name="attachmentLayout">Hint for how to display multiple
        /// attachments.</param>
        /// <param name="type">The type of the result</param>
        /// <param name="attachments">(Only when type is result)
        /// Attachments</param>
        /// <param name="suggestedActions">(Only when type of auth or config)
        /// Suggested actions</param>
        /// <param name="text">(Only when type is message) Text</param>
        public ComposeExtensionResult(string attachmentLayout = default(string), string type = default(string), System.Collections.Generic.IList<ComposeExtensionAttachment> attachments = default(System.Collections.Generic.IList<ComposeExtensionAttachment>), ComposeExtensionSuggestedAction suggestedActions = default(ComposeExtensionSuggestedAction), string text = default(string))
        {
            AttachmentLayout = attachmentLayout;
            Type = type;
            Attachments = attachments;
            SuggestedActions = suggestedActions;
            Text = text;
        }

        /// <summary>
        /// Gets or sets hint for how to display multiple attachments.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "attachmentLayout")]
        public string AttachmentLayout { get; set; }

        /// <summary>
        /// Gets or sets the type of the result
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets (Only when type is result) Attachments
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "attachments")]
        public System.Collections.Generic.IList<ComposeExtensionAttachment> Attachments { get; set; }

        /// <summary>
        /// Gets or sets (Only when type of auth or config) Suggested actions
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "suggestedActions")]
        public ComposeExtensionSuggestedAction SuggestedActions { get; set; }

        /// <summary>
        /// Gets or sets (Only when type is message) Text
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

    }


    /// <summary>
    /// Compose extension Actions (Only when type is auth or config)
    /// </summary>
    public partial class ComposeExtensionSuggestedAction
    {
        /// <summary>
        /// Initializes a new instance of the ComposeExtensionSuggestedAction
        /// class.
        /// </summary>
        public ComposeExtensionSuggestedAction() { }

        /// <summary>
        /// Initializes a new instance of the ComposeExtensionSuggestedAction
        /// class.
        /// </summary>
        /// <param name="actions">Actions</param>
        public ComposeExtensionSuggestedAction(System.Collections.Generic.IList<CardAction> actions = default(System.Collections.Generic.IList<CardAction>))
        {
            Actions = actions;
        }

        /// <summary>
        /// Gets or sets actions
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "actions")]
        public System.Collections.Generic.IList<CardAction> Actions { get; set; }

    }
}



namespace Microsoft.Bot.Connector.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Bot.Schema;
    using Models;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Activity extensions.
    /// </summary>
    public static class ActivityExtensions
    {
        /// <summary>
        /// Checks if the activity is a O365 connector card action query.
        /// </summary>
        /// <param name="activity">Incoming activity.</param>
        /// <returns>True is activity is a actionable card query, false otherwise.</returns>
        public static bool IsO365ConnectorCardActionQuery(this IInvokeActivity activity)
        {
            return activity.Type == ActivityTypes.Invoke &&
                !string.IsNullOrEmpty(activity.Name) &&
                activity.Name.StartsWith("actionableMessage/executeAction", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if the activity is a compose extension query.
        /// </summary>
        /// <param name="activity">Incoming activity.</param>
        /// <returns>True is activity is a compose extension query, false otherwise.</returns>
        public static bool IsComposeExtensionQuery(this IInvokeActivity activity)
        {
            return activity.Type == ActivityTypes.Invoke &&
                !string.IsNullOrEmpty(activity.Name) &&
                activity.Name.StartsWith("composeExtension", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the compose extension query data.
        /// </summary>
        /// <param name="activity">The activity.</param>
        /// <returns>Compose extension query data.</returns>
        public static ComposeExtensionQuery GetComposeExtensionQueryData(this IInvokeActivity activity)
        {
            return JObject.FromObject(activity.Value).ToObject<ComposeExtensionQuery>();
        }
    }
}
