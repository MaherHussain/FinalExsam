//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalEksamen
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserTb
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int Fk_Role { get; set; }
    
        public virtual RoleTb RoleTb { get; set; }
    }
}
