﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PathfinderPortraitManager.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.7.0.0")]
    internal sealed partial class CoreSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static CoreSettings defaultInstance = ((CoreSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new CoreSettings())));
        
        public static CoreSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("!NOTSET!")]
        public string WOTRPath {
            get {
                return ((string)(this["WOTRPath"]));
            }
            set {
                this["WOTRPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("!NOTSET!")]
        public string KINGPath {
            get {
                return ((string)(this["KINGPath"]));
            }
            set {
                this["KINGPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MaxWindowWidth {
            get {
                return ((int)(this["MaxWindowWidth"]));
            }
            set {
                this["MaxWindowWidth"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int MaxWindowHeight {
            get {
                return ((int)(this["MaxWindowHeight"]));
            }
            set {
                this["MaxWindowHeight"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("p")]
        public char GameType {
            get {
                return ((char)(this["GameType"]));
            }
            set {
                this["GameType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool EnabledCustomNPC {
            get {
                return ((bool)(this["EnabledCustomNPC"]));
            }
            set {
                this["EnabledCustomNPC"] = value;
            }
        }
    }
}
