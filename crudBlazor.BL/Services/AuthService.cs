using crudBlazor.BL.Repositories;
using crudBlazor.Model.Entities;

namespace crudBlazor.BL.Services;

public interface IAuthService
{
    Task<UserModel> GetUserByLogin(string username, string password);
    Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel);
    Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken);
}
public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public Task<UserModel> GetUserByLogin(string username, string password)
    {
        return authRepository.GetUserByLogin(username, password);
    }
    public async Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel)
    {
        await authRepository.RemoveRefreshTokenByUserID(refreshTokenModel.UserID);
        await authRepository.AddRefreshTokenModel(refreshTokenModel);
    }
    public Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken)
    {
        return authRepository.GetRefreshTokenModel(refreshToken);
    }
}
