﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Lithnet.ResourceManagement.Automation.RMConfigConverter
{
    public class ObjectSetting
    {
        public static List<string> DefaultAttributes
        {
            get
            {
                return new List<string>
                {
                    "CreatedTime",
                    "ObjectID",
                    "Creator",
                    "ComputedMember",
                    "MVObjectID",
                    "ResourceTime"
                };
            }
        }

        public static List<string> MinimumAttributes
        {
            get
            {
                return new List<string>
                {
                    "ObjectID",
                    "ObjectType"
                };
            }
        }

        public string ObjectType { get; set; }
        public List<string> AnchorAttributes { get; set; }

        public string IDPrefix { get; set; }

        public bool ReferenceResolution { get; set; }
        public List<string> ReferenceResolutionAttributExclusions { get; set; }

        public bool IncludeDefaultAttributes { get; set; }

        public bool IncludeEmptyAttributeValues { get; set; }

        public List<string> AttributExclusions { get; set; }

        public List<ObjectExclusion> ObjectSpecificExlusions { get; set; }

        internal static ObjectSetting GetDefaultObjectSetting(string ObjectType)
        {
            return new ObjectSetting()
            {
                ObjectType = ObjectType,
                AnchorAttributes = new List<string> { "ObjectID" },
                IDPrefix = "ObjectType",
                ReferenceResolution = true,
                IncludeDefaultAttributes = false,
                IncludeEmptyAttributeValues = false
            };
        }
    }

    [Cmdlet(VerbsCommon.New, "RMConverterObjectSetting")]
    public class NewObjectSetting : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public string ObjectType { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public string[] AnchorAttributes { get; set; }

        [Parameter(Mandatory = false, Position = 3)]
        public string IDPrefix { get; set; }

        [Parameter(Mandatory = false, Position = 4)]
        public SwitchParameter ReferenceResolution { get; set; }

        [Parameter(Mandatory = false, Position = 5)]
        public string[] ReferenceResolutionAttributExclusions { get; set; }

        [Parameter(Mandatory = false, Position = 6)]
        public SwitchParameter IncludeDefaultAttributes { get; set; }

        [Parameter(Mandatory = false, Position = 7)]
        public SwitchParameter IncludeEmptyAttributeValues { get; set; }

        [Parameter(Mandatory = false, Position = 8)]
        public List<string> AttributExclusions { get; set; }

        [Parameter(Mandatory = false, Position = 9)]
        public ObjectExclusion[] ObjectSpecificExlusions { get; set; }


        protected override void ProcessRecord()
        {
            this.WriteObject(
                new ObjectSetting()
                {
                    AnchorAttributes = AnchorAttributes?.ToList(),
                    AttributExclusions = AttributExclusions?.ToList(),
                    IDPrefix = IDPrefix,
                    IncludeDefaultAttributes = IncludeDefaultAttributes.IsPresent,
                    IncludeEmptyAttributeValues = IncludeEmptyAttributeValues.IsPresent,
                    ObjectSpecificExlusions = ObjectSpecificExlusions?.ToList(),
                    ObjectType = ObjectType,
                    ReferenceResolution = ReferenceResolution.IsPresent,
                    ReferenceResolutionAttributExclusions = ReferenceResolutionAttributExclusions?.ToList()
                });
        }
    }
}
