   M S B A M L   `   `   `  ????Q  MpayrollSystem Version2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:payrollSystem_Version2payrollSystem_Version2  5   	   *    $payrollSystem_Version2.hrPayrollList   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:payrollSystem_Version2     5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  Payroll List??5	   	   $??603.408??6   $??1049.521??6/    ? WindowStartupLocation$ CenterScreen=?6@   .??5
      ? ???	#FF374057$??-2,-7,0.2,0q?6"   $	??584??67   $	??Top=?6D   .+?5   
   ?? $
??Left=?6   $??42??60   $??
957,76,0,0q?6<   $	??Top=?6P   $??47??6h    J? RenderTransformOrigin$ 1.093,0.542&?6s   .+?5      ?? $??resources/search.png??6   $??
-3,0,0.6,0q?62   $??38??6F   5      ?? 5   
   -   5         ??Name$ label1_Copy3??5      $??Search:??6&   $
??Left=?68   $??25??6S   $??
624,91,0,0q?6_   $	??Top=?6s   $??68??6?   $??14(?6?   $??Cambria Math)?6?   ???	#FFD4F2E8$ 0.488,0.336&?6?   ?? 5   
   -   5         ??Name$ 	txtSearch??5      $
??Left=?6%   $??32??6@   $??
696,86,0,0q?6L    ?? TextWrapping$
 Wrap=?6`   $	??Top=?6t   $	??254??6?   $ 0.412,-0.03&?6?   ???	#FF76798A
???????$??16(?6
  $??Cambria Math)?6  ?? 5   
   -   5         ??Name$
 date??5      ???	#FFD4F2E8$??16(?6:   $??40??6H   $
??Bold"?6T   $
??Left=?6f   $??Center=?6?   $	??264??6?   $??19,16,0,528q?6?   ?? 6?   $?            ??6?   ?? 6?   $?9/26/2019 2:50:36 AM??6?   6?   ?? 5   
   $??Center=?6   $??870,14,14,535q?60   .+?5      '  !MaterialDesignThemes.Wpf.PopupBox  $??Stretch=?6&   $??111,5,8.8,5q?6D      PlacementMode$ BottomAndAlignRightEdges=?6Y      	StaysOpen .  ???	#FFFCFCFC	   PopupContent.	 5      ?? $	??150??6   .+?5      ?? -   5        
 ??Name$
 btnHome1??5      $
??Home??6/   ???	#FFD4AF376U   ?? 5      -   5        $
 btnAbout??5      $??About Us??6/   ???	#FFD4AF376Y   ?? 5      -   5        $
 
btnContact??5      $??
Contact Us??61   ???	#FFD4AF376]   ?? 5      ?? 5      -   5        $
 btnHelp??5      $
??Help??6.   ???	#FFD4AF376T   5      5      5      ?? 5   
   -   5        $ label??5      $??P??6   $
??Left=?6+   $??	33,21,0,0q?6F   $	??Top=?6Y   $	??116??6q   $??67??6~   $??Javanese Text)?6?   $
??Bold"?6?   $??72(?6?   ???	#FFD4AF376?   ?? 5   
   -	   5        $ label1??5      $??ayroll??6    $
??Left=?61   $??	74,75,0,0q?6L   $	??Top=?6_   $??50??6w   $	??122??6?   ???	#FFD4AF37$??Cambria Math)?6?   $??36(?6?   ?? 5    
   -
   5        $ label1_Copy??5       $
??List??6%   $
??Left=?64   $??
169,66,0,0q?6O   $	??Top=?6c   $??52??6{   $	??122??6?   ???	#FFF6F5F3$??Cambria Math)?6?   $??48(?6?   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ 	lvPayroll??5!      $??	0,0,29,28q?6&   ???	#FFFCFCF8$??Cambria Math)?6g   $??Normal"?6?   $??Disabled=?5"      $??Stretch=?6C    ? ToolTip$ Payroll of Employees??6h   $	??413??6?   $??Bottom=?6?   $ 0.5,0.5&?6?   $??Right=?6?   $	??991??6?   $??14(?6=   ? IsSharedSizeScope . $   HorizontalScrollBarVisibility$ Visible=?6i  ??5!   9   Z?    VerticalGridLinesBrush 5"   ?   Z?    HorizontalGridLinesBrush 6  Z? ??5#      ?? 5$       ?? EndPoint$ 0.5,0&?6&    ?? 
StartPoint$ 0.5,1&?67   .??5%      ?  ? Color$ 	#FF40E6B8??6#    ? Offset$ 0Q?65   ? 5&      $ 	#FF1AD4BC??6#   $ 0.109Q?65   ? 5'      $ 	#FF16C8C9??6#   $ 0.297Q?65   ? 5(      $ 	#FF2FB1C6??6#   $ 1Q?65   5)         Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Employee ID??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6R      
FontFamily$ Cambria Math)?6^      FontSize$ 14Q?6x      
FontWeight$
 Bold"?6?      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ?? *EID+6?     5-      $
 Name??6%   $	 150 6L   $ Cambria Math)?6X   $ 14Q?6r   $
 Bold"?6?      CanUserResize .   .  63   ?? *Name+6?     5.      $ Position??6%   $	 110 6T   $ Cambria Math)?6`   $ 14Q?6z   $
 Bold"?6?    .  67   ?? *
Position+6?     5/      $ 
Daily Rate??6%   $	 120 6W   $ Cambria Math)?6c   $ 14Q?6}   $
 Bold"?6?    .  69   ?? *	DailyRate+6?     50      $ no. of Days??6%   $	 100 6W   $ Cambria Math)?6c   $ 14Q?6}   $
 Bold"?6?    .  6:   ?? *
Num_days+6?     51      $ 	Rate Wage??6%   $	 130 6U   $ Cambria Math)?6a   $ 14Q?6{   $
 Bold"?6?    .  68   ?? *
RateWage+6?     52      $ OT hours??6%   $	 100 6S   $ Cambria Math)?6_   $ 14Q?6y   $
 Bold"?6?    .  67   ?? *	OThours+6?     53      $ Overtime Pay??6%   $	 120 6X   $ Cambria Math)?6d   $ 14Q?6~   $
 Bold"?6?    .  6;   ?? *
Overtime+6?     54      $ Night Differential??6%   $	 135 6g   $ Cambria Math)?6s   $ 14Q?6?   $
 Bold"?6?    .  6A   ?? *NightDifferential+6?     55      $ 
Philhealth??6%   $	 120 6X   $ Cambria Math)?6d   $ 14Q?6~   $
 Bold"?6?    .    
Foreground ?	#FFF6ECEC 69   ?? *
Philhealth+6?     56      $ Holliday Pay??6%   $	 125 6W   $ Cambria Math)?6c   $ 14Q?6}   $
 Bold"?6?    .  6;   ?? *	HollPay+6?     57      $ 	Basic Pay??6%   $	 120 6V   $ Cambria Math)?6b   $ 14Q?6|   $
 Bold"?6?    .  68   ?? *	Basic_Pay+6?     58      $ Cash Advance??6%   $	 120 6W   $ Cambria Math)?6c   $ 14Q?6}   $
 Bold"?6?    .  6;   ?? *	Cash_ad+6?     59      $ 
Philhealth??6%   $	 120 6X   $ Cambria Math)?6d   $ 14Q?6~   $
 Bold"?6?    ?	#FFF6ECEC 69   ?? *
Philhealth+6?     5:      $ Withholding Tax??6%   $	 130 6a   $ Cambria Math)?6m   $ 14Q?6?   $
 Bold"?6?    .  6>   ?? *WithholdingTax+6?     5;      $ Pag-ibig??6%   $	 120 6S   $ Cambria Math)?6_   $ 14Q?6y   $
 Bold"?6?    .  67   ?? *	Pagibig+6?     5<      $	 SSS??6%   $	 120 6J   $ Cambria Math)?6V   $ 14Q?6p   $
 Bold"?6~    .  62   ?? *SSS+6?     5=      $ Other Deduction??6%   $	 200 6]   $ Cambria Math)?6i   $ 14Q?6?   $
 Bold"?6?    .  6>   ?? *
OtherDeduc+6?     5>      $ Amount??6%   $	 120 6P   $ Cambria Math)?6\   $ 14Q?6v   $
 Bold"?6?    .  65   ?? *Amount+6?     5?      $ Total Deduction??6%   $	 120 6^   $ Cambria Math)?6j   $ 14Q?6?   $
 Bold"?6?    .  6>   ?? *Total_Deduc+6?     5@      $ 
Net Income??6%   $	 180 6X   $ Cambria Math)?6d   $ 14Q?6~   $
 Bold"?6?   
 ????? 69   ?? *
Net_income+6?     5A      $ Pay Day??6%   $	 105 6Q   $ Cambria Math)?6]   $ 14Q?6w   $
 Bold"?6?    .  .   66   ?? *PayDay+6?   5C      5E      5F      