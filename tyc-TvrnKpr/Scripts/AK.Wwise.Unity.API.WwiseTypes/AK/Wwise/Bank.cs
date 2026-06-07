using System;

namespace AK.Wwise
{
	[Serializable]
	public class Bank : BaseType
	{
		public WwiseBankReference WwiseObjectReference;

		public override WwiseObjectType WwiseObjectType => default(WwiseObjectType);

		public override WwiseObjectReference ObjectReference
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Load(bool decodeBank = false, bool saveDecodedBank = false)
		{
		}

		public void LoadAsync(AkCallbackManager.BankCallback callback = null)
		{
		}

		public void Unload()
		{
		}
	}
}
