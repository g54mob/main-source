using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Menu;
using ModApi;
using ModApi.CelestialData;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.UI
{
	public class IconGeneratorScript : MonoBehaviour
	{
		public const int TextureSize = 150;

		private ObjectViewerScript _objectViewer;

		private List<(string Name, CelestialFile File)> _starterPlanets = new List<(string, CelestialFile)>();

		public void SaveTexture(string path, Texture2D texture)
		{
			byte[] bytes = texture.EncodeToPNG();
			File.WriteAllBytes(path, bytes);
		}

		protected virtual void Start()
		{
			_objectViewer = GetComponent<ObjectViewerScript>();
			LoadItems();
			StartCoroutine(Generate());
		}

		private IEnumerator Generate()
		{
			yield return new WaitForEndOfFrame();
			foreach (var x in _starterPlanets)
			{
				GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("PlanetStudio/Prefabs/PreviewPlanet");
				MenuPlanetScript component = gameObject.GetComponent<MenuPlanetScript>();
				component.Initialize(_objectViewer.Light, _objectViewer.Camera);
				component.RotationSpeed = 0f;
				PlanetDataScript planetData = PlanetDataScript.CreateFromFile(x.File, null, null, null, createTerrainData: true, applyScaleAndOverrides: false);
				component.SetPlanetData(planetData);
				component.Eclipse = 0f;
				gameObject.gameObject.SetActive(value: true);
				_objectViewer.PreviewObject(gameObject);
				yield return new WaitForEndOfFrame();
				Render(x, _objectViewer.Camera);
				yield return new WaitForEndOfFrame();
			}
		}

		private void LoadItems()
		{
			CelestialDatabase db = Game.Instance.CelestialDatabase;
			foreach (var item in (from x in db.GetAllFiles(includingDuplicates: true, CelestialFileType.CelestialBody)
				where !db.SpecialFiles.AllFiles.Any((CelestialDatabase.CelestialDatabaseSpecialFile sf) => sf.Id == x.Id)
				select new
				{
					File = x,
					Info = db.GetCelestialBody(x.Id)
				} into x
				where x.Info != null
				where x.Info.IsTemplate
				select new
				{
					x.File,
					x.Info,
					x.File.Path.FileName,
					x.File.Path.InUserData,
					x.Info.Author,
					x.Info.Version
				} into x
				orderby x.Info.Name, x.InUserData, (!x.InUserData) ? x.Author : x.FileName, x.Version
				select x).ToList())
			{
				_starterPlanets.Add((item.Info.Name, item.File));
			}
		}

		private void Render((string Name, CelestialFile File) planet, Camera camera)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(1050, 1050, 32, RenderTextureFormat.ARGB32, RenderTextureReadWrite.sRGB);
			temporary.name = "PlanetIcon";
			temporary.antiAliasing = 8;
			RenderTexture active = RenderTexture.active;
			camera.targetTexture = temporary;
			RenderTexture.active = temporary;
			camera.Render();
			Texture2D texture2D = new Texture2D(temporary.width, temporary.height, TextureFormat.RGB24, mipChain: false, linear: false);
			texture2D.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
			texture2D.Apply();
			Texture2D texture = Utilities.Texture.CreateResizedTexture(texture2D, 150, 150);
			camera.targetTexture = null;
			RenderTexture.active = active;
			RenderTexture.ReleaseTemporary(temporary);
			SaveTexture(Application.dataPath + "/Resources/Ui/Sprites/PlanetStudio/PlanetTemplates/" + planet.Name + ".png", texture);
		}
	}
}
