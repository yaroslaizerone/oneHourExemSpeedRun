//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace oneHourExemSpeedRun.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAuth
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> role { get; set; }
    
        public virtual UserRole UserRole { get; set; }
    }
}