﻿#pragma checksum "..\..\pmCalendar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6464DE96CCCDE5EE62B35E9E8623029C247E45FD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using payrollSystem_Version2;


namespace payrollSystem_Version2 {
    
    
    /// <summary>
    /// pmCalendar
    /// </summary>
    public partial class pmCalendar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\pmCalendar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\pmCalendar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHome1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\pmCalendar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCalendar;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\pmCalendar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAbout;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\pmCalendar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnContact;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\pmCalendar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHelp;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\pmCalendar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
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
            System.Uri resourceLocater = new System.Uri("/payrollSystem Version2;component/pmcalendar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\pmCalendar.xaml"
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
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.btnHome1 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\pmCalendar.xaml"
            this.btnHome1.Click += new System.Windows.RoutedEventHandler(this.btnHome_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCalendar = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\pmCalendar.xaml"
            this.btnCalendar.Click += new System.Windows.RoutedEventHandler(this.btnCalendar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAbout = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\pmCalendar.xaml"
            this.btnAbout.Click += new System.Windows.RoutedEventHandler(this.btnAbout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnContact = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\pmCalendar.xaml"
            this.btnContact.Click += new System.Windows.RoutedEventHandler(this.btnContact_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnHelp = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\pmCalendar.xaml"
            this.btnHelp.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\pmCalendar.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

