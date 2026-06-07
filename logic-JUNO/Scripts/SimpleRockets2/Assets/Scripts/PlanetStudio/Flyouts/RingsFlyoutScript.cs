using System;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using ModApi.CelestialData;
using ModApi.Planet;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class RingsFlyoutScript : PlanetStudioFlyoutScript, ITextureSelector
	{
		public CelestialBodyDesignerScript Designer => PlanetStudioScript.Instance.CelestialBodyDesignerScript;

		public PlanetDataScript PlanetData => Designer.CurrentCelestialBody;

		public PlanetRingsData Rings => Designer.CurrentCelestialBody.RingsData;

		public void SelectTexture(TextureModel model, Action<string> onComplete)
		{
			PlanetStudioScript instance = PlanetStudioScript.Instance;
			PlanetStudioUIScript planetStudioUIScript = (PlanetStudioUIScript)instance.PlanetStudioUI;
			TexturePickerLibrary texturePickerLibrary = new TexturePickerLibrary(instance.CelestialBodyDesigner.CurrentCelestialBody?.FileData, model.TextureFilter);
			planetStudioUIScript.CreateTexturePicker(texturePickerLibrary, delegate(SupportFileData s, string p)
			{
				model.Label = s.FriendlyName;
				onComplete(p);
			});
		}

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
		}

		protected override void RefreshUI()
		{
			base.RefreshUI();
			InspectorModel inspectorModel = new InspectorModel("Rings", "Rings");
			inspectorModel.AddAndBuild(new ToggleModel("Has Rings", () => Rings.HasRings, OnHasRingsChanged)).Build(delegate(ToggleModel x)
			{
				x.Tooltip = "Toggles a ring system on/off for the celestial body.";
			});
			if (Rings.HasRings)
			{
				inspectorModel.AddAndBuild(new SliderModel("Inner Radius", () => (float)Rings.InnerRadiusScaled, delegate(float x)
				{
					Rings.InnerRadiusScaled = Math.Round(x, 3);
				}, 0f, 10f)).Build(delegate(SliderModel x)
				{
					x.ValueFormatter = (float v) => $"{v:f3}";
				}).Build(delegate(SliderModel x)
				{
					x.Tooltip = "The inner radius of the plantary ring system, scaled by the planet radius. A value of 1 will begin the rings at the surface of the celstial body.";
				});
				inspectorModel.AddAndBuild(new SliderModel("Outer Radius", () => (float)Rings.OuterRadiusScaled, delegate(float x)
				{
					Rings.OuterRadiusScaled = Math.Round(x, 3);
				}, 0f, 10f)).Build(delegate(SliderModel x)
				{
					x.ValueFormatter = (float v) => $"{v:f3}";
				}).Build(delegate(SliderModel x)
				{
					x.Tooltip = "The outer radius of the plantary ring system, scaled by the planet radius. A value of 2 will end the rings at a distance of the planet radius from the surface of the celstial body.";
				});
				inspectorModel.AddAndBuild(new Vector3InputModel("Rotation", () => Rings.Rotation, delegate(Vector3 x)
				{
					Rings.Rotation = x;
				})).Build(delegate(Vector3InputModel x)
				{
					x.Tooltip = "The euler angles defining the rotation of the rings relative to the celestial body.";
				});
				inspectorModel.AddAndBuild(new TextureModel("Rings Texture", this, delegate
				{
					string texture = Rings.Texture;
					return PlanetStudioScript.Instance.CelestialBodyDesigner.GetSupportFile(texture)?.Path.FullPath;
				}, delegate(string x)
				{
					string orCreateSupportFileReference = PlanetStudioScript.Instance.CelestialBodyDesigner.GetOrCreateSupportFileReference(x);
					Rings.Texture = orCreateSupportFileReference;
				})).Build(delegate(TextureModel x)
				{
					x.Tooltip = "The texture for the rings. This should only need to be a single pixel in height (and whatever width is desired). Textures more than one pixel in height can be selected, but only a single row of pixels is actually used for the rings.";
				});
			}
			BuildFromModel(inspectorModel);
		}

		private void OnHasRingsChanged(bool hasRings)
		{
			Rings.HasRings = hasRings;
			RefreshUI();
		}
	}
}
