   M S B A M L   `   `   `  ����F  BText Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Text_EditorText_Editor  5   	       Text_Editor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Text_Editor     5   	   -   5          �Name$  
mainWindow��5   	    � Title$ 
TID Editor��5   	   $	��452��6   $	��800��6)    � Icon$% /Resources/Icons/poo-icon-0.jpg��65   ���	#FFFF1D1D$��10(�6t    � SizeToContent$ Manual=�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� -   5         ��Name$ richTextBox��5      $��0,18,0,0q�6+   $��Arial)�6=   $��10(�6P   $��2,1,2,1q�6^   ��.   �� 
AcceptsTab .  J� SnapsToDevicePixels . 	 � 
InputScope$	 Default��6�   
 � 	Resources
 5       �� 
TargetType �� Property �� Value��%X   'J�       �� 5      " J�6   .�5      ��  �@��Margin$ 0q�6/   5      5      . �5      /� 5      o� 5   
   -   5         o�Name$ MenuBar��5      
�������$��18��63   $	��Top=�6?   
���  ��.@�5      m� -   5         m�Name$ fileMenuItem��5      $
��File��6-   
�������.@�5      m� -   5        $ newMenuItem��5      $	��New��60   6=   m� 5      -   5        $ newWindowMenuItem��5      $��
New Window��66   6J   m� 5      -   5        $ openMenuItem��5      $��Open...��61   6B   m� 5      -   5        $ saveMenuItem��5      $
��Save��61   6?   m� 5      -	   5        $ saveAsMenuItem��5      $��
Save As...��63   6G   �� 5       m� 5!      -
   5        $ pageSetupMenuItem��5!      $��Page Setup...��66   6M   m� 5"      -   5        $ printMenuItem��5"      $��Print...��62   6D   �� 5#      m� 5$      -   5        $ 
exitButton��5$      $
��Exit��6/   6=   5%      m� 5&      -   5        $ editMenuItem��5&      $
��Edit��6-   .@�5'      m� -   5        $ undoMenuItem��5'      $
��Undo��61   6?   �� 5(      m� 5)      -   5        $ cutMenuItem��5)      $	��Cut��60   6=   m� 5*      -   5        $ copyMenuItem��5*      $
��Copy��61   6?   m� 5+      -   5        $ pasteMenuItem��5+      $��Paste��62   6A   �� 5,      m� 5-      -   5        $ findMenuItem��5-      $��Find...��61   6B   m� 5.      -   5        $ findNextMenuItem��5.      $��	Find Next��65   6H   m� 5/      -   5        $ findPreviousMenuItem��5/      $��Find Previous��69   6P   m� 50      -   5        $ replaceMenuItem��50      $��Replace��64   6E   m� 51      -   5        $ goToMenuItem��51      $��Go to��61   6@   �� 52      m� 53      -   5        $ selectAllMenuItem��53      $��
Select All��66   6J   m� 54      -   5        $ insertDateMenuItem��54      $��Insert Date��67   6L   55      m� 56      -   5        $ formatMenuItem��56      $��Format��6/   .@�57      m� -   5        $ wordWrapMenuItem��57      $��	Word Wrap��65    m� IsCheckable . 6_   m� 58      -   5        $ fontMenuItem��58      $��Font...��61   6B   59      m� 5:      -   5        $ viewMenuItem��5:      $
��View��6-   .@�5;      m� -   5        $ zoomMenuItem��5;      $
��Zoom��61   .@�5<      m� -   5        $ zoomInMenuItem��5<      $��MenuItem��67   6I   m� 5=      -   5        $ zoomOutMenuItem��5=      68   m� 5>      -    5        $ defaultZoomMenuItem��5>      6<   5?      m� 5@      -!   5        $ statusBarMenuItem��5@      $��
Status Bar��66    . 6b   5A      m� 5B      -"   5        $ settingsMenuItem��5B      $��
Settings
��61   .@�5C      m� -#   5        $ settingsMenuItem1��5C      $��Settings...��66   6K   m� 5D      -$   5        $ macrosMenuItem��5D      $��	Macros...��63   6F   5E      m� 5F      -%   5        $ helpMenuItem��5F      $��Help
��6-   5G      �� 5H   
   -&   5         ��Name$ fileStatusBar��5H      $��Center=�6+   $��1��6F   .@�5I      �� -'   5         ��Name$ editedStatusBarItem��5I      $��Edited: False��69   $��17��6Q   $��Center=�6]   $��8(�6x   
�������}�. 6�   5J      5K      5L      