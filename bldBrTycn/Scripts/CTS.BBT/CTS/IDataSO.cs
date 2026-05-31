using UnityEngine;

namespace CTS
{
	public interface IDataSO<TOBject, TDataStruct> where TOBject : ScriptableObject where TDataStruct : AbsBalancingDataStruct
	{
		bool HasNewValues(TDataStruct dataStruct);

		TOBject CreateCopyWithNewValues(TDataStruct dataStruct);

		static TOBject CreateCopyWithNewValues(TOBject original, TDataStruct data)
		{
			if (!(original is IDataSO<TOBject, TDataStruct> dataSO))
			{
				return null;
			}
			TOBject result = Object.Instantiate(original);
			dataSO.SetNewValues(data);
			return result;
		}

		void SetNewValues(TDataStruct dataStruct);
	}
}
