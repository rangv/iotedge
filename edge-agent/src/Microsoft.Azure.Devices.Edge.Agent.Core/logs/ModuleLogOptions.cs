// Copyright (c) Microsoft. All rights reserved.
namespace Microsoft.Azure.Devices.Edge.Agent.Core.Logs
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.Devices.Edge.Util;

    public class ModuleLogOptions : IEquatable<ModuleLogOptions>
    {
        public ModuleLogOptions(
            LogsContentEncoding contentEncoding,
            LogsContentType contentType,
            ModuleLogFilter filter,
            LogOutputFraming outputFraming,
            Option<LogsOutputGroupingConfig> outputGroupingConfig,
            bool follow)
        {
            this.ContentEncoding = contentEncoding;
            this.ContentType = contentType;
            this.Filter = Preconditions.CheckNotNull(filter, nameof(filter));
            this.OutputFraming = outputFraming;
            this.OutputGroupingConfig = outputGroupingConfig;
            this.Follow = follow;
        }

        public LogsContentEncoding ContentEncoding { get; }

        public LogsContentType ContentType { get; }

        public ModuleLogFilter Filter { get; }

        public LogOutputFraming OutputFraming { get; }

        public Option<LogsOutputGroupingConfig> OutputGroupingConfig { get; }

        public bool Follow { get; }

        public override bool Equals(object obj)
            => this.Equals(obj as ModuleLogOptions);

        public bool Equals(ModuleLogOptions other)
            => other != null &&
               this.ContentEncoding == other.ContentEncoding &&
               this.ContentType == other.ContentType &&
               EqualityComparer<ModuleLogFilter>.Default.Equals(this.Filter, other.Filter);

        public override int GetHashCode()
        {
            var hashCode = -1683996196;
            hashCode = hashCode * -1521134295 + this.ContentEncoding.GetHashCode();
            hashCode = hashCode * -1521134295 + this.ContentType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<ModuleLogFilter>.Default.GetHashCode(this.Filter);
            return hashCode;
        }
    }
}
