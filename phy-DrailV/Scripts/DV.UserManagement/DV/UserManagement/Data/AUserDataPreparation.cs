using DV.UserManagement.Storage;
using UnityEngine;

namespace DV.UserManagement.Data
{
	public abstract class AUserDataPreparation : MonoBehaviour
	{
		public abstract void PrepareDataBeforeInit(IStorageProvider storage, UserManager mgr);

		public abstract void PrepareDataAfterInit(IStorageProvider storage, UserManager mgr);
	}
}
