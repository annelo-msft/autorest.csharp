// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace CognitiveServices.TextAnalytics.Models.VV30Preview1
{
    public partial class LanguageBatchInput
    {
        public ICollection<LanguageInput> Documents { get; set; } = new List<LanguageInput>();
    }
}