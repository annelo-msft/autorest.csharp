// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class MultiLanguageInput : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            if (Language != null)
            {
                writer.WritePropertyName("language");
                writer.WriteStringValue(Language);
            }
            writer.WriteEndObject();
        }
        internal static MultiLanguageInput DeserializeMultiLanguageInput(JsonElement element)
        {
            MultiLanguageInput result = new MultiLanguageInput();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    result.Text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("language"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Language = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
    }
}