   M S B A M L   `   `   `  ����J  FNewsApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:NewsApplicationNewsApplication  5      #    NewsApplication.Authorization   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:NewsApplication     5      $	��650��5	      $	��725��6     N� Title$  Authorization��5
       N� 
Background �	#FF3C3CFF.��5      � ��5   
   �� 5       �� ImageSource$ Photos\background_1.jpg��6    j� Stretch$ UniformToFill=�6?    � ColumnDefinitions 5   
   �� 5      �� 5      $��300pt �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��30pt �6   �� 5      $
��30pt �6   �� 5      $
��30pt �6   �� 5      $
��30pt �6   �� 5      $
��30pt �6   �� 5      $
��30pt �6   �� 5      $
��30pt �6   �� 5      .+�5    
   �� -   5         ��Name$ 	textBlock��5       $��24(�6'   $��2��65    �� TextAlignment$ Center=�6B   $��1��6Y   $��Вход��6j   $��	58,0,56,5q�6v   
�������$��30��6�   $��Bottom=�6�    � Cursor$
 None��6�   �� 5!   
   -   5        $ 
textBlock1��5!      $��16(�6(   $��
Логин��66   $��29��6C   $��0��6R   $��3��6b   $ Right=�6o   $��
77,8,10,11q�6�   
�������6�   �� 5"   
   -   5        	 ��Name$	 AuthorizationLogin��5"      $��1��6.   
 �� TextAlignment$
 Justify=�6>   $��18(�6V   $��29��6d   $��3��6s   $��0,4,0,7q�6�   �� 5#   
   -   5        $ 
textBlock2��5#      $��Пароль��6(   $��4��66   $��0��6C   $ Right=�6S   $��
69,8,10,12q�6i   
�������$��16(�6�   G� 5$   
   -   5         G�Name$ AuthorizationPassword��5$      $��1��65   $��18(�6E   $��4��6S   $��0,2,0,9q�6`   �� 5%   
   -   5         ��Name$ button��5%      $��Вход��6!   $��16(�6G   ���	#FF3C3CFF$��1��6l   $��5��6|    �� 	IsDefault . $��	0,3,204,5q�6�   }�. 
�������$
 Hand��6�   �� 5&   
   -   5        $ button1��5&      $��Регистрация��6"   $��1��68   $��5��6H   $��16(�6U   $��	201,3,0,5q�6y   ���	#FF87C9FF
�������$
 Hand��6�   5'      5(      