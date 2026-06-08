using System.Collections.Generic;
using Shapes;
using TMPro;
using UnityEngine;

namespace Kitchen
{
	public class PlayerIdentificationComponent : MonoBehaviour
	{
		[Header("Configuration")]
		[SerializeField]
		private bool UseNameLabel;

		[Header("References")]
		[SerializeField]
		private List<Renderer> PlayerColourRenderers = new List<Renderer>();

		[SerializeField]
		private RegularPolygon PlayerDisc;

		[SerializeField]
		private RegularPolygon PlayerDisc2;

		[SerializeField]
		private Transform NameContainer;

		[SerializeField]
		private TextMeshPro NameLabel;

		[Header("State")]
		private int PlayerID;

		protected ComponentListBinding<Color> ColourBinding;

		protected ComponentBinding<int> IndicatorSidesBinding;

		private static readonly int Color0 = Shader.PropertyToID("_Color0");

		public virtual void Setup(PlayerView player_view)
		{
			List<Component> list = new List<Component>();
			list.AddRange(PlayerColourRenderers);
			list.Add(PlayerDisc);
			list.Add(PlayerDisc2);
			ColourBinding = new ComponentListBinding<Color>(list, delegate(Color c)
			{
				if (PlayerColourRenderers != null)
				{
					foreach (Renderer playerColourRenderer in PlayerColourRenderers)
					{
						player_view.RegisterDisposable(playerColourRenderer.material).SetColor(Color0, c);
					}
				}
				Color color = c;
				color.a = 0.75f;
				if (PlayerDisc != null)
				{
					PlayerDisc.Color = color;
				}
				color.a = 0.25f;
				if (PlayerDisc2 != null)
				{
					PlayerDisc2.Color = color;
				}
			}, Color.red);
			IndicatorSidesBinding = new ComponentBinding<int>(PlayerDisc, delegate(int c)
			{
				if (PlayerDisc != null)
				{
					RegularPolygon playerDisc = PlayerDisc;
					playerDisc.Sides = c switch
					{
						0 => 10, 
						1 => 3, 
						2 => 4, 
						_ => 6, 
					};
					PlayerDisc.Roundness = ((c == 0) ? 1f : 0.25f);
					PlayerDisc.Radius = ((PlayerDisc.Sides == 3) ? 0.6f : 0.5f);
					PlayerDisc.transform.localPosition = new Vector3(0f, 0.1f + (float)c * 0.02f, 0f);
				}
				if (PlayerDisc2 != null)
				{
					RegularPolygon playerDisc = PlayerDisc2;
					playerDisc.Sides = c switch
					{
						0 => 10, 
						1 => 3, 
						2 => 4, 
						_ => 6, 
					};
					PlayerDisc2.Roundness = ((c == 0) ? 1f : 0.25f);
					PlayerDisc2.Radius = ((PlayerDisc2.Sides == 3) ? 0.6f : 0.5f);
					PlayerDisc2.transform.localPosition = new Vector3(0f, 0.1f + (float)c * 0.02f, 0f);
				}
			}, -1);
			Players.Main.OnPlayerInfoChanged += UpdateProfile;
		}

		private void OnDestroy()
		{
			Players.Main.OnPlayerInfoChanged -= UpdateProfile;
		}

		private void Update()
		{
			if (UseNameLabel && NameContainer != null)
			{
				NameContainer.rotation = Quaternion.identity;
			}
		}

		public virtual void UpdateData(int player_id)
		{
			if (player_id != PlayerID)
			{
				PlayerID = player_id;
				UpdateProfile();
			}
		}

		public void UpdateProfile()
		{
			if (Players.Main.Has(PlayerID))
			{
				PlayerInfo playerInfo = Players.Main.Get(PlayerID);
				ColourBinding.Value = playerInfo.Profile.Colour;
				IndicatorSidesBinding.Value = playerInfo.Index;
				if (UseNameLabel && NameContainer != null)
				{
					NameLabel.text = Players.Main.Get(PlayerID).Profile.Name;
				}
			}
		}
	}
}
