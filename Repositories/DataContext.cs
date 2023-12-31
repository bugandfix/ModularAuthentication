﻿using Microsoft.EntityFrameworkCore;
using ModularAuthentication.Entities;

namespace ModularAuthentication.Repositories;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<RolePrivilege> RolePrivilege { get; set; }
}