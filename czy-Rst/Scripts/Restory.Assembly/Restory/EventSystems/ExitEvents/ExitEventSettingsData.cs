using System;
using System.Collections.Generic;
using Restory.Data.Identifications;
using UnityEngine;

namespace Restory.EventSystems.ExitEvents
{
	[Serializable]
	public class ExitEventSettingsData
	{
		[SerializeField]
		private UniqueIdentificator identificator;

		[SerializeField]
		private int layerOrder = -1;

		[SerializeField]
		private List<UniqueIdentificator> subordinates;

		[SerializeField]
		private List<UniqueIdentificator> incompatibles;

		public UniqueIdentificator Identificator => identificator;

		public int LayerOrder => layerOrder;

		public List<UniqueIdentificator> Subordinates => subordinates;

		public List<UniqueIdentificator> Incompatibles => incompatibles;

		private string GetHeaderName()
		{
			if (!identificator)
			{
				return null;
			}
			return identificator.ID;
		}
	}
}
