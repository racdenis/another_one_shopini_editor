   M S B A M L   `   `   `  ���� I  ESHOPINI Editor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:SHOPINI_EditorSHOPINI_Editor  E'clr-namespace:SHOPINI_Editor.PropertiesSHOPINI_Editor.Properties      SHOPINI_Editor.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:SHOPINI_Editor     7res'clr-namespace:SHOPINI_Editor.Properties     -     �Name$  AppMainWindow��)   #SHOPINI_Editor.Properties.Resources   	main_form � Title# Z $��612.833��$	��787��$	��400��$	��200�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      SHOPINI_Editor.MainWindow   SaveShopCommand   Command# Z  J� InputBindings ��  �� Command$&  local:MainWindow.SaveShopCommand�� �� 	Modifiers$ Controlf�
	 �� Key$	 S��.��� $��0,0,0,6q�
 � ColumnDefinitions
 �� $
��185* ��� $
��294* ��� $
��136* ��� $
��164* �.+�o� $	��Top=�$��4��.@�m� -    m�Name$ MenuItem_file��   file#��Z .@�m� -   $ MenuItem_createshop��   create_shop#��Z m� -   $ MenuItem_openshop��   	open_shop#��Z m� -   $ MenuItem_saveshop��   	save_shop#��Z  m� InputGestureText$ Ctrl+S��m� -   $ MenuItem_saveshopas��   save_shop_as#��Z �� m� -   $ MenuItem_exit��   exit#��Z m� -	   $��English��$��56��m� -
   $��Русский��m� -   $ MenuItemHelp��   help_menuitem#��Z �� -    ��Name$ ListBoxMain1��$��10,203,10,85q�$��4��$��Stretch=� �� SelectionMode$ Extended=��� -    ��Name$ ITEMINFO_label��   iteminfo_not_ok#��Z $��	10,23,0,0q�$	��Top=�
���   �$
��Left=�$	��126���� -   $ Label_itemtext��   	item_text#��Z $��
10,172,0,0q�$
��Left=�$	��364��$��26��$	��Top=�$��2���� -   $ Label_leveltext��   
level_text#��Z $��194,172,0,0q�$��26��$	��Top=�$
��Left=�$��58��$��1���� -   $ Label_pricetext��   
price_text#��Z $��257,172,10,0q�$��26��$	��Top=�$��1��$��3���� -   $ Label_rusname��   shopname_text_ru#��Z $
��Left=�$��	10,49,0,0q�$	��Top=��� -    ��Name$ TextBoxShopnameRus��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��207��$��
167,52,0,0q�$��Тест��$��2���� -   $ TextBoxShopnameEng��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��207��$��
167,78,0,0q�$
��Test��$��2��{�.  �� -   $ Label_pricecoeff��   pricecoeff_text#��Z $
��Left=�$��
10,130,0,0q�$	��Top=��� -   $ TextBoxPriceCoeff��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��207��$��167,133,0,0q�$��0��$��2���� -    ��Name$ TypeComboBox��$
��Left=�$	��207��$��167,106,0,0q�  �� SelectedIndex$  0��$��22��$	��Top=�$��2��.@��� $��0���� $��1���� $��2���� -   $ Label_typetext��!   	type_text#��Z! $
��Left=�$��
10,101,0,0q�$	��Top=��� -   $ ClassnameComboBox��$
��Left=�$��	11,0,0,32q�$	��350��" �� StaysOpenOnEdit" . $��2��$��22��$��Bottom=�# �� 
IsEditable# . $ �� IsTextSearchEnabled$ .  �� -   $ RealNameComboBox��$
��Left=�$��11,0,0,6q�$	��350��# . " . $��22��$��Bottom=�$��2��$ .  �� -   $ Predmetlabel��#��Z $
��Left=�$��	11,0,0,54q�$��Bottom=��� -   $ 
Levellabel��#��Z $
��Left=�$��
181,0,0,54q�$��Bottom=�$��1���� -   $ 
Pricelabel��#��Z $
��Left=�$��
242,0,0,54q�$��Bottom=�$��1��% J� RenderTransformOrigin$% 4.658,0.551&��� -   $ LevelTextBox��$
��Left=�$��22��$��
181,0,0,32q�$
 Wrap=�$��1��$��Bottom=�$��56��$��1���� -   $ PriceTextBox��$��242,0,10,32q�$
 Wrap=�$��0��$��22��$��Bottom=�$��1��$��3���� -   & ��Name$& ButtonApplyChange��'   apply_change#��Z' $
��Left=�$��	181,0,0,6q�$	��200��$��1��$��22��$��Bottom=�{�.  $��2���� -    $& ButtonAddLine��(   add_new#��Z( $
��Left=�$��90,0,0,6q�$	��200��$��2��$��22��$��Bottom=�$��2���� -!   $ StealthClassnameComboBox��$��1��$
��Left=�$��23��$��242,121,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�$��2������ ) �� ElementName$) ClassnameComboBox��* �� Path$
* Text��� -"   $ StealthRealnameComboBox��$��1��$
��Left=�$��23��$��
242,93,0,0q�$
 Wrap=�$	��Top=�$	��120��$y�Hidden=�$��2������ *Text+$) RealNameComboBox���� -#   + ��Name$+ Label_engname��,   shopname_text_en#��Z, $
��Left=�$��	14,81,0,0q�$	��Top=�$	��148��-   eng_version_mark. � ToolTip#. Z- 