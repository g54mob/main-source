using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class GeneralRepository : TRepository<GeneralRepository>
	{
		[SerializeField]
		private GeneralSave m_Save = new GeneralSave();

		[SerializeField]
		private GeneralAudio m_Audio = new GeneralAudio();

		public override string RepositoryID => "core.general";

		public GeneralAudio Audio => m_Audio;

		public GeneralSave Save => m_Save;
	}
}
