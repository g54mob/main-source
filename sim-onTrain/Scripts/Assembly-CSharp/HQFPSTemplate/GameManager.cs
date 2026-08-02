using System.Collections.Generic;
using HQFPSTemplate.UserInterface;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HQFPSTemplate
{
	public class GameManager : Singleton<GameManager>
	{
		[BHeader("General", true)]
		[SerializeField]
		private SceneField[] m_GameScenes;

		[Space]
		[SerializeField]
		private Texture2D m_CustomCursorTex;

		[Space]
		[SerializeField]
		[Tooltip("This will help with stuttering and lag when loading new objects for the first time, but will increase the memory usage right away.")]
		private bool m_PreloadMaterialsInEditor;

		[SerializeField]
		private Material[] m_PreloadedMaterials;

		public Material[] PreloadedMaterials
		{
			get
			{
				return m_PreloadedMaterials;
			}
			set
			{
				m_PreloadedMaterials = value;
			}
		}

		public Player CurrentPlayer { get; set; }

		public UIManager CurrentInterface { get; set; }

		public void Quit()
		{
			Application.Quit();
		}

		public void StartGame(int index = -1)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			if (index == -1)
			{
				SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
			}
			else
			{
				SceneManager.LoadSceneAsync(m_GameScenes[index].SceneName, LoadSceneMode.Single);
			}
		}

		public void SetPlayerPosition()
		{
			CurrentPlayer.transform.position = GetSpawnPoint();
			CurrentPlayer.transform.rotation = GetSpawnRotation();
		}

		private Vector3 GetSpawnPoint()
		{
			PlayerSpawnPoints playerSpawnPoints = Object.FindObjectOfType<PlayerSpawnPoints>();
			Vector3 result = CurrentPlayer.transform.position;
			if (playerSpawnPoints != null)
			{
				Vector3 randomSpawnPoint = playerSpawnPoints.GetRandomSpawnPoint();
				if (randomSpawnPoint != Vector3.zero)
				{
					result = randomSpawnPoint;
				}
			}
			return result;
		}

		private Quaternion GetSpawnRotation()
		{
			PlayerSpawnPoints playerSpawnPoints = Object.FindObjectOfType<PlayerSpawnPoints>();
			Quaternion result = CurrentPlayer.transform.rotation;
			if (playerSpawnPoints != null)
			{
				result = playerSpawnPoints.GetRandomRotation();
			}
			return result;
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		private new void Awake()
		{
			OnSceneLoaded();
			if (Singleton<GameManager>.Instance != null && Singleton<GameManager>.Instance != this)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			if (Application.isEditor && m_PreloadMaterialsInEditor)
			{
				List<GameObject> list = new List<GameObject>();
				Camera component = new GameObject("Material Preload Camera", typeof(Camera)).GetComponent<Camera>();
				component.orthographic = true;
				component.orthographicSize = 100f;
				component.farClipPlane = 100f;
				component.depth = 999f;
				component.renderingPath = RenderingPath.Forward;
				bool flag = (component.allowDynamicResolution = false);
				bool flag3 = (component.allowMSAA = flag);
				bool useOcclusionCulling = (component.allowHDR = flag3);
				component.useOcclusionCulling = useOcclusionCulling;
				list.Add(component.gameObject);
				Material[] preloadedMaterials = m_PreloadedMaterials;
				foreach (Material material in preloadedMaterials)
				{
					if (!(material == null))
					{
						GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
						gameObject.transform.position = component.transform.position + component.transform.forward * 50f + component.transform.right * Random.Range(-100f, 100f) + component.transform.up * Random.Range(-100f, 100f);
						gameObject.transform.localScale = Vector3.one * 0.01f;
						gameObject.GetComponent<Renderer>().sharedMaterial = material;
						list.Add(gameObject);
					}
				}
				component.Render();
				foreach (GameObject item in list)
				{
					Object.Destroy(item);
				}
				list.Clear();
			}
			if (m_CustomCursorTex != null)
			{
				Cursor.SetCursor(m_CustomCursorTex, Vector2.zero, CursorMode.Auto);
			}
			Object.DontDestroyOnLoad(base.gameObject);
		}

		private void OnSceneLoaded()
		{
		}

		private void Start()
		{
		}
	}
}
