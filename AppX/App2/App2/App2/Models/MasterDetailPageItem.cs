using System;
using System.Collections.Generic;
using System.Text;

namespace App2.MenuItems
{
    public enum MenuItemType
    {
        Home,
        Saved,
        Setting
    }
    public class MasterDetailPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public MenuItemType Id { get; set; }
    }
}
