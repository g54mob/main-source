using System.Collections;
using Assets.Source.Player;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T7PowerOverseer : MonoBehaviour
	{
		[SerializeField]
		private T7PowerSlider[] _sliders;

		[SerializeField]
		private ActiveWorldFrame _frame;

		[SerializeField]
		private FrameGizmoShaker _shaker;

		private int _overchargeTier;

		private void OnEnable()
		{
			ClearOvercharge();
			_frame = GetComponentInParent<ActiveWorldFrame>();
			SetupPuzzle();
		}

		public void SetShakerAmplitude(float x, float y)
		{
			FrameGizmoShaker[] componentsInChildren = GetComponentsInChildren<FrameGizmoShaker>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].SetAmplitude(x, y);
			}
		}

		public void SetupPuzzle()
		{
			T7PowerSlider[] sliders = _sliders;
			for (int i = 0; i < sliders.Length; i++)
			{
				sliders[i].SetNotch(SeededRandom.Global.RandomFloat());
			}
		}

		public void ClearOvercharge()
		{
			_overchargeTier = 0;
			_shaker.ForceActive = false;
			SetShakerAmplitude(0.02f, 0.05f);
		}

		public void CraftingTrigger()
		{
			T7PowerSlider[] sliders = _sliders;
			for (int i = 0; i < sliders.Length; i++)
			{
				if (!sliders[i].IsSolved())
				{
					StartCoroutine(FailPuzzle());
					return;
				}
			}
			ClearOvercharge();
			_frame.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			StartCoroutine(ResetPuzzle());
		}

		private IEnumerator FailPuzzle()
		{
			string text = "@T7PowerOvercharge1";
			bool flag = false;
			bool flag2 = true;
			T7PowerSlider[] sliders = _sliders;
			for (int i = 0; i < sliders.Length; i++)
			{
				if (sliders[i].Progress < 0.99f)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				sliders = _sliders;
				for (int i = 0; i < sliders.Length; i++)
				{
					sliders[i].Randomize();
				}
				_overchargeTier++;
				if (_overchargeTier == 1)
				{
					_shaker.ForceActive = true;
					SetShakerAmplitude(0.02f, 0.05f);
				}
				else if (_overchargeTier == 2)
				{
					text = "@T7PowerOvercharge2";
					SetShakerAmplitude(0.03f, 0.08f);
				}
				else if (_overchargeTier == 3)
				{
					text = "@T7PowerOvercharge3";
					SetShakerAmplitude(0.08f, 0.08f);
				}
				else
				{
					text = "@T7PowerOvercharge4";
					SetShakerAmplitude(0.15f, 0.15f);
					flag = true;
				}
			}
			else
			{
				ClearOvercharge();
			}
			_frame.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), text);
			if (flag)
			{
				yield return new WaitForSeconds(1f);
				for (int j = 0; j < base.transform.childCount; j++)
				{
					base.transform.GetChild(j).gameObject.SetActive(value: false);
					yield return new WaitForSeconds(0.2f);
				}
				yield return new WaitForSeconds(2f);
				WorldMap.Current.SetTerrain(_frame.ActiveFrame.Position, 9);
				WorldMap.Current.RemoveFrame(_frame.ActiveFrame);
				SteamAchievement.Trigger("NuclearOvercharge");
				GameUI.Instance.ShowFullScreenUI(OverviewUI.Instance);
			}
			yield return null;
		}

		public IEnumerator ResetPuzzle()
		{
			yield return new WaitForSeconds(1f);
			SetupPuzzle();
		}
	}
}
