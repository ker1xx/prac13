   M S B A M L   `   `   `  ????A  =prac13, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:prac13prac13  5   	       prac13.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=1.0.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:prac13     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      $	?? 2* ?6    ? RowDefinitions 5   
   ?? 5      $
??0.4* ?6   ?? 5      $
??1.8* ?6   ?? 5      $
??0.5* ?6   ?? 5      $??* ?6   .+?5   
   ?? -   5         ??Name$ 	all_songs??5      $??1??6%   $??6??62   $
??Left=?6F   $??20(?6h   5      ?? 5   
   -   5         ??Name$ Open_folder??5      $1??+Открыть папку с музыкой??6&   $??6??6H   $??Center=?6]   $??	30,0,30,0q?6x   6?   ?? 5   
   -   5        $ Previous??5      $??3??6#   $??0??60   
?????????5      ?? 5      -   5        previous_image?? ?? ImageSource$ /previous.png??5   5   5       ?? 5!   
   -   5        $ 
Play_pause??5!      $??3??6%   $??1??62   
?????????5"      ?? 5#      -   5        play_pause_image??$ 
/13021.png??5#   7   5%      ?? 5&   
   -   5        $
 Next??5&      $??3??6   $??2??6,   
?????????5'      ?? 5(      -   5        
next_image??$ /right_arrow.png??5(   1   5*      ?? 5+   
   -	   5        $ Shuffle??5+      $??3??6"   $??3??6/   
?????????5,      ?? 5-      -
   5        shuffle_image??$ /shuffle.png??5-   4   5/      ?? 50   
   -   5        $ Repeat??50      $??3??6!   $??4??6.   
?????????51      ?? 52      -   5        repeat_image??$ /repeat.png??52   3   54      r? 55   
   -   5         r?Name$ Media??55       r? LoadedBehavior$ Manual=?6&   6>   ?? 56   
   -   5         ??Name$ Volume??56      $??2??6!   $??3??65   $??5??6B   $??Center=?6R   $??30q?6m   6y   ?? 57   
   -   5        $ Timeline??57      $??6??6#   $??2??67   $??
30,10,30,0q?6D   $	??Top=?6X   6p   ?? 58   
   -   5        	 ??Name$	 CurrentTimer??58      $??0??6&   $??2??66   $??Bottom=?6C   $
??Left=?6^   $??10,0,0,2q?6y   ?? 59   
   -   5        $	 DurationOfSong??59      $??5??6(   $??2??68   $??Bottom=?6E   $??Right=?6`   $??0,0,10,2q?6|   5:      5;      