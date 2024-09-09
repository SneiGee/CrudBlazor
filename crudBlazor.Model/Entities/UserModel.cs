namespace crudBlazor.Model.Entities;

public class UserModel
{
    public UserModel()
    {
        UserRoles = new List<UserRoleModel>();
    }
    public int ID { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public virtual ICollection<UserRoleModel> UserRoles { get; set; }
}
