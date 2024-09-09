namespace crudBlazor.Model.Entities;

public class UserRoleModel
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public int RoleID { get; set; }
    public virtual required RoleModel Role { get; set; }
    public virtual required UserModel User { get; set; }
}
