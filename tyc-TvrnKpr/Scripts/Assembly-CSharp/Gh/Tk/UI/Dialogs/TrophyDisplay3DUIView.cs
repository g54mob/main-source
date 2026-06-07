using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class TrophyDisplay3DUIView : Button3DUIView
	{
		protected DissolveArea3DUIView _dissolveArea;

		[SerializeField]
		protected Transform _trophySocket;

		[SerializeField]
		protected Transform _plaqueSocket;

		protected Trophy3DUIView _trophy;

		protected TrophyPlaque3DUIView _plaque;

		[SerializeField]
		protected List<GameObject> _plaquePrefabs;

		protected const int LargePlaqueCharacterThreshold = 50;

		[SerializeField]
		private Collider _trophyCollider;

		private Trophy3DUIView CreateTrophy()
		{
			return null;
		}

		protected virtual Trophy3DUIView CreateTrophyInternal()
		{
			return null;
		}

		private TrophyPlaque3DUIView CreatePlaque()
		{
			return null;
		}

		protected virtual TrophyPlaque3DUIView CreatePlaqueInternal()
		{
			return null;
		}

		protected virtual void UpdateVisuals()
		{
		}

		protected void SetDissolveMaterials(GameObject go)
		{
		}

		private void UpdateDissolveMaterials()
		{
		}

		protected override void Start()
		{
		}

		protected virtual TooltipData CreateTooltip()
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected void UpdateDisplayState()
		{
		}

		protected virtual bool IsTrophyEnabled()
		{
			return false;
		}
	}
}
