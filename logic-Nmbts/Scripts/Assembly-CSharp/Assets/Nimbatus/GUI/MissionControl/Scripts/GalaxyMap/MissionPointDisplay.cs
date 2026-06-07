using Assets.Nimbatus.Scripts.Missions;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class MissionPointDisplay : MonoBehaviour
	{
		public Sprite Low;

		public Sprite Medium;

		public Sprite Hard;

		public SpriteRenderer Renderer;

		public Color CompletedColor;

		public Color NotCompletedColor;

		public Material CompletedMaterial;

		public Material NotCompletedMaterial;

		public void Init(EMissionDifficulty difficulty, bool missionCompleted)
		{
			switch (difficulty)
			{
			case EMissionDifficulty.None:
				Renderer.sprite = null;
				break;
			case EMissionDifficulty.Low:
				Renderer.sprite = Low;
				break;
			case EMissionDifficulty.Medium:
				Renderer.sprite = Medium;
				break;
			case EMissionDifficulty.Hard:
				Renderer.sprite = Hard;
				break;
			}
			if (missionCompleted)
			{
				if (Renderer.material != CompletedMaterial)
				{
					Renderer.material = CompletedMaterial;
				}
				Renderer.color = CompletedColor;
			}
			else
			{
				if (Renderer.material != NotCompletedMaterial)
				{
					Renderer.material = NotCompletedMaterial;
				}
				Renderer.color = NotCompletedColor;
			}
		}
	}
}
