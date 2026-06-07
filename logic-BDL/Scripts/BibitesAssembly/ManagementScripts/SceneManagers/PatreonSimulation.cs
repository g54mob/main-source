using System;
using System.Collections.Generic;
using System.Linq;
using ScriptHelpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ManagementScripts.SceneManagers
{
	public class PatreonSimulation : MonoBehaviour
	{
		public const string path = "Patrons/";

		public const string pathHerbivores = "herbivores/";

		public const string pathCarnivores = "carnivores/";

		public const string pathRockstars = "rockstars/";

		public static float totalTime = 210f;

		public static float cameraSize = 300f;

		public static int n = 4;

		public static Vector2 cameraBounds = new Vector2(cameraSize * 1920f / 1080f, cameraSize);

		public static Vector2 simulationBounds = n * cameraBounds;

		private float turningBound;

		private float travelLength;

		private Camera cam;

		public Transform popupHolder;

		public GameObject customBibitePrefab;

		public GameObject baseBibitePrefab;

		public GameObject pelletPrefab;

		public Transform patreonsHolder;

		public GameObject button;

		private List<PatreonInfo> pelletPatreons = new List<PatreonInfo>();

		private List<PatreonInfo> bibitePatreons = new List<PatreonInfo>();

		private List<Texture2D> textures = new List<Texture2D>();

		private Vector3 camDir = Vector3.right;

		private float camSpeed;

		private float turnTime;

		private float turnProgress;

		private bool start;

		private float spawnProgress;

		private float approximateDelay;

		private bool turning;

		private bool goingRight = true;

		private bool goingUp = true;

		private bool spawnedAll;

		public static PatreonSimulation instance;

		private void Start()
		{
			instance = this;
			cam = Camera.main;
			Time.timeScale = 0f;
			cam.orthographicSize = cameraSize;
			PopupManager.popupHolder = popupHolder;
			travelLength = 2f * cameraBounds.x * (float)n * (float)n + (1.1415927f * cameraBounds.y - 2f * cameraBounds.x) * (float)n;
			travelLength += -1.1415927f * cameraBounds.y;
			turningBound = (float)(n - 1) * cameraBounds.x - cameraBounds.y;
			turnTime = totalTime * MathF.PI * cameraBounds.y / travelLength;
			camSpeed = travelLength / totalTime;
			LoadPatreons();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				SceneManager.LoadScene("Menu");
			}
			if (!start)
			{
				return;
			}
			if (Time.timeScale < 1f)
			{
				Time.timeScale += Time.unscaledDeltaTime / 10f;
			}
			if (goingRight && cam.transform.position.x >= turningBound)
			{
				goingRight = false;
				turning = true;
			}
			if (!goingRight && cam.transform.position.x <= 0f - turningBound)
			{
				goingRight = true;
				turning = true;
			}
			if (turning)
			{
				int num = ((goingRight ^ goingUp) ? 1 : (-1));
				turnProgress += Time.deltaTime;
				camDir = Quaternion.Euler(0f, 0f, (float)(num * 180) * Time.deltaTime / turnTime) * camDir;
				if (turnProgress >= turnTime)
				{
					turning = false;
					turnProgress = 0f;
					camDir = (goingRight ? 1 : (-1)) * Vector3.right;
					if (goingUp && cam.transform.position.y > simulationBounds.y - cameraBounds.y * 1.1f)
					{
						goingUp = false;
					}
					if (!goingUp && cam.transform.position.y < 0f - (simulationBounds.y - cameraBounds.y * 1.1f))
					{
						goingUp = true;
					}
				}
			}
			cam.transform.position += camDir * camSpeed * Time.deltaTime;
			spawnProgress += Time.deltaTime;
			if (!spawnedAll && !(spawnProgress < approximateDelay))
			{
				spawnProgress -= approximateDelay;
				PatreonInfo patreonInfo = bibitePatreons.FirstOrDefault((PatreonInfo p) => !p.spawned);
				if (patreonInfo == null)
				{
					spawnedAll = true;
					return;
				}
				SpawnBibitePatron(patreonInfo);
				patreonInfo.spawned = true;
			}
		}

		public void StartSimulation()
		{
			pelletPatreons.Shuffle();
			bibitePatreons.Shuffle();
			approximateDelay = (totalTime - 10f) / (float)bibitePatreons.Count;
			cam.transform.position = new Vector3(cameraBounds.x * (float)(1 - n), cameraBounds.y * (float)(1 - n), -5f);
			float num = 2.5f * (float)bibitePatreons.Count - (float)pelletPatreons.Count;
			foreach (PatreonInfo pelletPatreon in pelletPatreons)
			{
				SpawnPelletPatron(pelletPatreon, SpawnPosition.InSim);
			}
			for (int i = 0; (float)i < num; i++)
			{
				SpawnPelletPatron(null, SpawnPosition.InSim);
			}
			foreach (PatreonInfo item in bibitePatreons.Take(bibitePatreons.Count / (n * n)))
			{
				item.spawned = true;
				SpawnBibitePatron(item, SpawnPosition.InCam);
			}
			button.SetActive(value: false);
			start = true;
		}

		public void LoadPatreons()
		{
			ClearTextures();
			pelletPatreons.Clear();
			bibitePatreons.Clear();
			if (LoadPatreonInfoFromCSV(pelletPatreons, "Patrons/", "pellets", PatreonTier.Pellet) && LoadPatreonInfoFromCSV(bibitePatreons, "Patrons/", "eggs", PatreonTier.Egg) && LoadPatreonInfoFromCSV(bibitePatreons, "Patrons/", "herbivores", PatreonTier.Herbivore) && LoadPatreonInfoFromCSV(bibitePatreons, "Patrons/", "carnivores", PatreonTier.Carnivore) && LoadPatreonInfoFromCSV(bibitePatreons, "Patrons/", "rockstars", PatreonTier.RockStar))
			{
				int num = 0;
				num += LoadPatreonsInfoFromFolder(bibitePatreons, "Patrons/", "herbivores/", PatreonTier.Herbivore);
				num += LoadPatreonsInfoFromFolder(bibitePatreons, "Patrons/", "carnivores/", PatreonTier.Carnivore);
				num += LoadPatreonsInfoFromFolder(bibitePatreons, "Patrons/", "rockstars/", PatreonTier.RockStar);
				if (num > 0)
				{
					PopupManager.DisplayChoiceDialog("Patreon Simulation", "There was " + num + " missing patreons sprites. missing.csv files have been generated.", "Sad, Cancel", "Go with it!", null, StartSimulation);
				}
				else
				{
					StartSimulation();
				}
			}
		}

		private bool LoadPatreonInfoFromCSV(List<PatreonInfo> list, string folder, string file, PatreonTier tier)
		{
			TextAsset textAsset = Resources.Load<TextAsset>(folder + file);
			if (textAsset == null)
			{
				return false;
			}
			string[] array = textAsset.text.Replace("\r", "").Split("\n"[0]);
			foreach (string value in array)
			{
				if (!string.IsNullOrEmpty(value))
				{
					list.Add(new PatreonInfo
					{
						name = value,
						tier = tier
					});
				}
			}
			return true;
		}

		private int LoadPatreonsInfoFromFolder(List<PatreonInfo> list, string path, string folder, PatreonTier tier)
		{
			string text = path + folder;
			List<string> list2 = new List<string>();
			foreach (PatreonInfo item in list)
			{
				if (item.tier == tier)
				{
					string text2 = item.name.Replace(":", "").Replace(".", "").Replace("\\", "")
						.Replace("/", "")
						.Replace("\"", "")
						.Replace("|", "")
						.Replace("?", "")
						.Replace("<", "")
						.Replace(">", "")
						.Replace("*", "");
					if (text2[text2.Length - 1] == ' ')
					{
						text2 = text2.Remove(text2.Length - 1);
					}
					Texture2D texture2D = Resources.Load<Texture2D>(text + text2);
					if (texture2D == null)
					{
						list2.Add(item.name);
						continue;
					}
					textures.Add(texture2D);
					item.image = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(24f / 35f, 0.5f), 1f, 0u, SpriteMeshType.FullRect, Vector4.zero, generateFallbackPhysicsShape: false);
				}
			}
			return list2.Count;
		}

		private void ClearTextures()
		{
			textures.Clear();
		}

		private void SpawnPelletPatron(PatreonInfo patreon, SpawnPosition spawn = SpawnPosition.JustOutsideCam)
		{
			Vector3 position = Vector3.zero;
			switch (spawn)
			{
			case SpawnPosition.InCam:
				position = new Vector3(cameraBounds.x * UnityEngine.Random.Range(-1f, 1f), cameraBounds.y * UnityEngine.Random.Range(-1f, 1f), 0f);
				break;
			case SpawnPosition.InSim:
				position = new Vector3(simulationBounds.x * UnityEngine.Random.Range(-1f, 1f), simulationBounds.y * UnityEngine.Random.Range(-1f, 1f), 0f);
				break;
			case SpawnPosition.JustOutsideCam:
				position = cam.transform.position - 5f * Vector3.back + JustOutsideCam();
				break;
			case SpawnPosition.OutCam:
				position = cam.transform.position - 5f * Vector3.back + OutsideOfCam();
				break;
			}
			UnityEngine.Object.Instantiate(pelletPrefab, position, Quaternion.identity, patreonsHolder).GetComponent<PatreonPellet>().InitializePatron(patreon);
		}

		private void SpawnBibitePatron(PatreonInfo patreon, SpawnPosition spawn = SpawnPosition.JustOutsideCam)
		{
			Vector3 position = Vector3.zero;
			Quaternion rotation = Quaternion.identity;
			switch (spawn)
			{
			case SpawnPosition.InCam:
				position = cam.transform.position + new Vector3(cameraBounds.x * UnityEngine.Random.Range(-1f, 1f), cameraBounds.y * UnityEngine.Random.Range(-1f, 1f), 5f);
				rotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 360f));
				break;
			case SpawnPosition.InSim:
				position = new Vector3(simulationBounds.x * UnityEngine.Random.Range(-1f, 1f), simulationBounds.y * UnityEngine.Random.Range(-1f, 1f), 0f);
				rotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 360f));
				break;
			case SpawnPosition.JustOutsideCam:
			{
				Vector3 vector = JustOutsideCam();
				position = cam.transform.position + 5f * Vector3.forward + vector;
				rotation = Quaternion.Euler(0f, 0f, Vector2.SignedAngle(Vector2.up, 3f * camDir * camSpeed - vector) + UnityEngine.Random.Range(-15f, 15f));
				break;
			}
			case SpawnPosition.OutCam:
				position = cam.transform.position + 5f * Vector3.forward + OutsideOfCam();
				rotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 360f));
				break;
			}
			UnityEngine.Object.Instantiate((patreon.tier == PatreonTier.Egg) ? baseBibitePrefab : customBibitePrefab, position, rotation, patreonsHolder).GetComponent<PatreonBibite>().InitializePatron(patreon);
		}

		private Vector3 JustOutsideCam()
		{
			float num = 2f * cameraBounds.x + 100f;
			float num2 = 2f * cameraBounds.y + 100f;
			float num3 = 2f * num + 2f * num2;
			float num4 = ((camDir.x > 0f) ? (num / 2f) : (3f * num / 2f + num2)) + UnityEngine.Random.Range(0f, num3 / 2f);
			if (num4 > num3)
			{
				num4 -= num3;
			}
			if (num4 < num)
			{
				return new Vector3(num4 - num / 2f, num2 / 2f, 0f);
			}
			num4 -= num;
			if (num4 < num2)
			{
				return new Vector3(num / 2f, num4 - num2 / 2f, 0f);
			}
			num4 -= num2;
			if (num4 < num)
			{
				return new Vector3(num4 - num / 2f, (0f - num2) / 2f, 0f);
			}
			num4 -= num;
			return new Vector3((0f - num) / 2f, num4 - num2 / 2f, 0f);
		}

		private Vector3 OutsideOfCam()
		{
			if (n < 2)
			{
				return Vector3.zero;
			}
			float num = 0f;
			float num2 = 0f;
			Vector3 position = cam.transform.position;
			int num3 = 0;
			do
			{
				num = UnityEngine.Random.Range(-1f, 1f) * simulationBounds.x;
				num2 = UnityEngine.Random.Range(-1f, 1f) * simulationBounds.y;
				num3++;
			}
			while (num3 < 10 && Mathf.Abs(num - position.x) < cameraBounds.x + 25f && Mathf.Abs(num2 - position.y) < cameraBounds.y + 25f);
			return new Vector3(num, num2, 0f);
		}

		public void PatreonDeath(PatreonTier tier, string patron)
		{
			if (tier == PatreonTier.Pellet)
			{
				PatreonInfo patreon = pelletPatreons.FirstOrDefault((PatreonInfo p) => p.name == patron);
				SpawnPelletPatron(patreon, SpawnPosition.InSim);
				return;
			}
			PatreonInfo patreonInfo = bibitePatreons.FirstOrDefault((PatreonInfo p) => p.name == patron);
			if (patreonInfo != null)
			{
				SpawnBibitePatron(patreonInfo, SpawnPosition.OutCam);
			}
		}

		private void OnDestroy()
		{
			ClearTextures();
		}
	}
}
