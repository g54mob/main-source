using Cysharp.Threading.Tasks;

namespace Assets.Scripts.Craft
{
	public delegate UniTask PreStartInitializationDelegate(AircraftScript craftScript, CraftLoadContext loadContext, bool async);
}
