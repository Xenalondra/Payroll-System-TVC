   M S B A M L   `   `   `  ????Q  MpayrollSystem Version2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:payrollSystem_Version2payrollSystem_Version2  5   	   *    $payrollSystem_Version2.AdminEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:payrollSystem_Version2     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  Employee List??5	   	   $??739.27??6   $??1193.677??6/    ? 
ResizeMode$ CanResizeWithGrip=?6@    ? WindowStartupLocation$ CenterScreen=?6_   .??5
      ? $??0,0,0.2,0.2q?6   .+?5   
   ? ???	#FF374057$??
0,0,0,-2.6q?6&   .+?5      ?? $
??Left=?6   $??57??64   $??1073,85,0,0q?6@   $	??Top=?6U   $??57??6m    J? RenderTransformOrigin$ 1.093,0.542&?6x   .+?5      ?? $??resources/search.png??6   $??-3,0,-0.2,0q?66   $??53??6K   5      ?? 5      -   5         ??Name$ label1_Copy3??5      $??Search Employee:??6*   $
??Left=?6E   $??43??6`   $??
573,99,0,0q?6l   $	??Top=?6?   $	??194??6?   $??24(?6?   $??Cambria Math)?6?   ???	#FFD4F2E86?   ?? 5      -   5         ??Name$ 	txtSearch??5      $
??Left=?6)   $??29??6D   $??772,103,0,0q?6P    ?? TextWrapping$
 Wrap=?6e   $	??Top=?6y   $	??298??6?   $ 0.412,-0.03&?6?   ???	#FF76798A
???????$??Cambria Math)?6  $??16(?6)  &   System.Windows.Controls.DataGrid  5      -   5          Name$ 
dtgemplist??5      $??0,170,38.2,0q?6+   
???????$??Cambria Math)?6r   $??Normal"?6?   $??Disabled=?6?   $??Stretch=?6?    ? ToolTip$ Employee Details??6?   $	??504??6  $	??Top=?6#  $ 0.5,0.5&?6;  $??Right=?6[  $
??1110??6w  $??14(?6?  ??6A   Z? 	   VerticalGridLinesBrush	 6?  Z? 
   HorizontalGridLinesBrush
 6?  Z? z?5      V? 5      .~?5      ?? ?? 5      ?? 5       ?? Angle$ 0.225Q?6*   T? 5      5      ??5      ?? 5       ?? EndPoint$ 0.5,0&?6*    ?? 
StartPoint$ 0.5,1&?6;   .??5      ?  ? Color$ 	#FF27C8FD??6'    ? Offset$ 0Q?69   ? 5      $ 	#FF50A0FD??6'   $ 0.339Q?69   ? 5       $ 	#FF5A84F5??6'   $ 0.661Q?69   ? 5!      $ 	#FF6589FD??6'   $ 1Q?69   5"         Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ 
EmployeeID??6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6\      
FontFamily$ Cambria Math)?6h      FontSize$ 14Q?6?      
FontWeight$
 Bold"?6?      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   ?? *
EmployeeID+6?     5'      $
 Name??6)   $	 200 6P   $ Cambria Math)?6\   $ 14Q?6v   $
 Bold"?6?    .  67   ?? *Name+6?     5(      $	 Age??6)   $	 100 6N   $ Cambria Math)?6Z   $ 14Q?6t   $
 Bold"?6?    .  66   ?? *Age+6?     5)      $ Gender??6)   $	 150 6T   $ Cambria Math)?6`   $ 14Q?6z   $
 Bold"?6?    .  69   ?? *Gender+6?     5*      $ Status??6)   $	 120 6T   $ Cambria Math)?6`   $ 14Q?6z   $
 Bold"?6?    .  69   ?? *Status+6?     5+      $ Address??6)   $	 250 6V   $ Cambria Math)?6b   $ 14Q?6|   $
 Bold"?6?    .  6:   ?? *	Address+6?     5,      $ Contact??6)   $	 200 6V   $ Cambria Math)?6b   $ 14Q?6|   $
 Bold"?6?    .  6:   ?? *	Contact+6?   5.      ?? 50      $??Center=?6   $??1013,15,13.2,662.2q?64   .+?51      '  !MaterialDesignThemes.Wpf.PopupBox  $??Stretch=?6*   $??111,5,8.8,5q?6H      PlacementMode$ BottomAndAlignRightEdges=?6]      	StaysOpen .  ???	#FFFCFCFC   PopupContent. 52      ?? $	??150??6!   .+?53      ?? -   5         ??Name$ btnHome??53   !   $
??Home??62   ???	#FFD4AF376X   ?? 54      -   5        $ btnAbout??54   !   $??About Us??63   ???	#FFD4AF376]   ?? 55      -   5        $ 
btnContact??55   !   $??
Contact Us??65   ???	#FFD4AF376a   ?? 56      ?? 57      -   5        $
??Help??57   !   ???	#FFD4AF376G   58      59      5:      ?? 5;      -   5         ??Name$
 date??5;      ???	#FFD4F2E8$??16(?6>   $??40??6L   $
??Bold"?6X   $
??Left=?6j   $??Center=?6?   $	??264??6?   $??33,26,0,646.2q?6?   ?? 6?   $?            ??6?   ?? 6?   $?9/26/2019 2:50:36 AM??6?   6  ?? 5<      -	   5        $ label??5<      $??E??6#   $
??Left=?6/   $??	35,42,0,0q?6J   $	??Top=?6]   $	??116??6u   $??67??6?   $??Javanese Text)?6?   $
??Bold"?6?   $??72(?6?   ???	#FFD4AF376?   ?? 5=      -
   5        $ label1??5=      $??mployee??6$   $
??Left=?66   $??	86,92,0,0q?6Q   $	??Top=?6d   $??50??6|   $	??143??6?   ???	#FFD4AF37$??Cambria Math)?6?   $??36(?6?   ?? 5>      -   5        $ label1_Copy??5>      $
??List??6)   $
??Left=?68   $??
221,85,0,0q?6S   $	??Top=?6g   $??52??6   $	??122??6?   ???	#FFF6F5F3$??Cambria Math)?6?   $??48(?6?   5@      5A      5B      