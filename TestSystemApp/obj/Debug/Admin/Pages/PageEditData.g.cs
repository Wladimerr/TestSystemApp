#pragma checksum "..\..\..\..\Admin\Pages\PageEditData.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B337BA52B115B596A1079FBE9592F4A85F3D778B13B65EC8ADACCA28AA33AB3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TestSystemApp.Admin.Pages;


namespace TestSystemApp.Admin.Pages {
    
    
    /// <summary>
    /// PageEditData
    /// </summary>
    public partial class PageEditData : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Admin\Pages\PageEditData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgTests;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Admin\Pages\PageEditData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbQuestions;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Admin\Pages\PageEditData.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgQuestions;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TestSystemApp;component/admin/pages/pageeditdata.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Admin\Pages\PageEditData.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\Admin\Pages\PageEditData.xaml"
            ((TestSystemApp.Admin.Pages.PageEditData)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgTests = ((System.Windows.Controls.DataGrid)(target));
            
            #line 19 "..\..\..\..\Admin\Pages\PageEditData.xaml"
            this.dgTests.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgTests_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\..\Admin\Pages\PageEditData.xaml"
            this.dgTests.DataContextChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.dgTests_DataContextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbQuestions = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.dgQuestions = ((System.Windows.Controls.DataGrid)(target));
            
            #line 29 "..\..\..\..\Admin\Pages\PageEditData.xaml"
            this.dgQuestions.DataContextChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.dgQuestions_DataContextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

