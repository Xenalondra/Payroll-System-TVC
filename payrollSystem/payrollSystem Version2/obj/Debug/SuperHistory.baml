   M S B A M L   `   `   `  ????Q  MpayrollSystem Version2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:payrollSystem_Version2payrollSystem_Version2  5   	   )    #payrollSystem_Version2.SuperHistory   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:payrollSystem_Version2     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        ? Title$  Transaction History??5	   	   $??756.61??6%   $??1123.85??65    ? 
ResizeMode$ NoResize=?6E    ? WindowStartupLocation$ CenterScreen=?6[   .??5
      ? $??0,0,-2.4,-3.8q?6   ???	#FF374057.+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	lvHistory??5       ? ToolTip$ Transaction History??6&   $??Cambria Math)?6[   $??16(?6u   $
??Bold"?6?   
???????$??Disabled=?6?   $??Stretch=?6?   $	??457??6  $	??Top=?6   J? RenderTransformOrigin$ 0.5,0.5&?6(  $
??Left=?6H  $	??970??6c  $??
74,175,0,0q?6?  ??6D   Z?    VerticalGridLinesBrush 6o  Z?    HorizontalGridLinesBrush 6?  Z? ??5      ?? 5       ?? EndPoint$ 0.5,1&?6&   	 ?? 
StartPoint$	 0.5,0&?67   .??5      ? 
 ? Color$
 	#FF877BED??6#    ? Offset$ 1Q?65   ? 5      $
 	#FFED89E7??6#   ? 5      $
 	#FFC37FF3??6#   $ 0.527Q?65   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 User??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 63      
FontFamily$ Cambria Math)?6X      FontSize$ 14Q?6r      
FontWeight$
 Bold"?6?      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ?? *User+6?     5      $ Transaction History??6%   $	 500 6B   $ Cambria Math)?6j   $ 14Q?6?   $
 Bold"?6?    .  6N   ?? *	History+6?     5      $
 Date??6%   $	 100 63   $ Cambria Math)?6X   $ 14Q?6r   $
 Bold"?6?    .  6?   ?? *Date+6?   5      ?? 5   
   -   5         ??Name$
 date??5      ???	#FFD4F2E8$??16(?6:   $??35??6H   $
??Bold"?6T   $
??Left=?6f   $??Center=?6?   $	??264??6?   $??27,24,0,667q?6?   ?? 6?   $?            ??6?   ?? 6?   $?9/26/2019 2:50:36 AM??6?   6?   ?? 5   
   $??Center=?6   $??952,19,18.6,673q?60   .+?5      '  !MaterialDesignThemes.Wpf.PopupBox  $??Stretch=?6&   $??
82,5,9.6,5q?6D      PlacementMode$ BottomAndAlignRightEdges=?6X      	StaysOpen .  ???	#FFFCFCFC   PopupContent. 5      ?? $	??150??6   .+?5      ?? -   5         ??Name$ btnHome??5      $
??Home??6.   ???	#FFD4AF376T   ?? 5      -   5        $ btnAbout??5      $??About Us??6/   ???	#FFD4AF376Y   ?? 5      -   5        $ 
btnContact??5      $??
Contact Us??61   ???	#FFD4AF376]   ?? 5       ?? 5!      -   5        $
??Help??5!      ???	#FFD4AF376C   5#      5$      5%      ?? 5&   
   $
??Left=?6   $??57??60   $??1027,90,0,0q?6<   $	??Top=?6Q   $??57??6i   $ 1.093,0.542&?6t   .+?5'      ?? $??resources/search.png??6   $??-3,0,-0.2,0q?62   $??53??6G   5(      ?? 5)   
   -   5         ??Name$ label1_Copy3??5)      $??Search:??6&   $
??Left=?68   $??43??6S   $??
644,98,0,0q?6_   $	??Top=?6s   $??85??6?   $??24(?6?   $??Cambria Math)?6?   ???	#FFD4F2E8$ 0.498,0.414&?6?   ?? 5*   
   -   5         ??Name$ 	txtSearch??5*      $
??Left=?6%   $??29??6@   $??731,104,0,0q?6L    ?? TextWrapping$
 Wrap=?6a   $	??Top=?6u   $	??298??6?   $ 0.412,-0.03&?6?   ???	#FF76798A
???????$??16(?6?   $??Cambria Math)?6?   6  ?? 5+   
   -	   5        $ label??5+      $??A??6   $
??Left=?6+   $??	64,36,0,0q?6F   $	??Top=?6Y   $	??116??6q   $??67??6~   $??Javanese Text)?6?   $
??Bold"?6?   $??72(?6?   ???	#FFD4AF376?   ?? 5,   
   -
   5        $ label1??5,      $
??udit??6    $
??Left=?6/   $??
117,95,0,0q?6J   $	??Top=?6^   $??50??6v   $	??174??6?   ???	#FFD4AF37$??Cambria Math)?6?   $??36(?6?   ?? 5-   
   -   5        $ label1_Copy??5-      $??Trail??6%   $
??Left=?65   $??
180,85,0,0q?6P   $	??Top=?6d   $??65??6|   $	??193??6?   ???	#FFF6F5F3$??Cambria Math)?6?   $??48(?6?   $ 0.528,0.493&?6?   5.      5/      