//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OracleMVCTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class STAFF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STAFF()
        {
            this.SESSIONS = new HashSet<SESSION>();
        }
    
        public decimal STAFF_ID { get; set; }
        public string STAFF_NAME { get; set; }
        public string STAFF_DESIGNATION { get; set; }
        public string STAFF_TYPE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SESSION> SESSIONS { get; set; }
    }
}
