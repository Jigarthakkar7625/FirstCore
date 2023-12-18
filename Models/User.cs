using System;
using System.Collections.Generic;

namespace FirstCore.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}
