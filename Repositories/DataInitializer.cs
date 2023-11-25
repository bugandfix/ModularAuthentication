using ModularAuthentication.Constants;
using ModularAuthentication.Entities;

namespace ModularAuthentication.Repositories;

public static class DataInitializer
{
    public static void Run(DataContext db)
    {
        if (db.User.Any()) return;
        
        // create role
        var adminRole = new Role
        {
            Name = "Administrator"
        };
        db.Role.Add(adminRole);
        
        var operatorRole = new Role
        {
            Name = "Operator"
        };
        db.Role.Add(operatorRole);

        db.SaveChanges();
        
        
        // create privileges
        db.RolePrivilege.Add(new RolePrivilege
        {
            RoleId = adminRole.Id,
            Privilege = PrivilegeConst.ReadUser
        });
        
        db.RolePrivilege.Add(new RolePrivilege
        {
            RoleId = adminRole.Id,
            Privilege = PrivilegeConst.CreateUser
        });
        
        db.RolePrivilege.Add(new RolePrivilege
        {
            RoleId = operatorRole.Id,
            Privilege = PrivilegeConst.ReadUser
        });

        db.SaveChanges();
        
        
        // create user
        var ali = new User
        {
            Username = "Ali",
            Password = "Ali",
            RoleId = adminRole.Id
        };
        db.User.Add(ali);
        
        var reza = new User
        {
            Username = "Reza",
            Password = "Reza",
            RoleId = operatorRole.Id
        };
        db.User.Add(reza);
        
        db.SaveChanges();
    }
}