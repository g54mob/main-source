using System;
using UnityEngine;
using UnityEngine.UI;

namespace ToonyColorsPro.Demo
{
	public class TCP2_Demo_Cat : MonoBehaviour
	{
		[Serializable]
		public class Ambience
		{
			public string name;

			public GameObject[] activate;

			public Material skybox;
		}

		[Serializable]
		public class ShaderStyle
		{
			[Serializable]
			public class CharacterSettings
			{
				public Material material;

				public Renderer[] renderers;
			}

			public string name;

			public CharacterSettings[] settings;
		}

		public Ambience[] ambiences;

		public int amb;

		[Space]
		public ShaderStyle[] styles;

		public int style;

		[Space]
		public GameObject shadedGroup;

		public GameObject flatGroup;

		[Space]
		public Animation[] catAnimation;

		public Animation[] unityChanAnimation;

		[Space]
		public GameObject[] cats;

		public GameObject[] unityChans;

		public GameObject unityChanCopyright;

		[Space]
		public Light catDirLight;

		public Light unityChanDirLight;

		[Space]
		public AnimationClip[] catAnimations;

		private int catAnim;

		public AnimationClip[] unityChanAnimations;

		private int uchanAnim;

		[Space]
		public Light[] dirLights;

		public Light[] otherLights;

		public Transform rotatingPointLights;

		[Space]
		public Button[] ambiencesButtons;

		public Button[] stylesButtons;

		public Button[] characterButtons;

		public Button[] textureButtons;

		public Button[] animationButtons;

		[Space]
		public Canvas canvas;

		private bool animationPaused;

		private float playingSpeed = 1f;

		public bool rotateLights { get; set; }

		public bool rotatePointLights { get; set; }

		private void Awake()
		{
			rotatePointLights = true;
			rotateLights = false;
			SetAmbience(0);
			SetStyle(0);
			SetCat(cat: true);
			SetFlat(flat: false);
			SetAnimation(0);
		}

		private void Update()
		{
			if (rotateLights)
			{
				Light[] array = dirLights;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].transform.Rotate(Vector3.up * Time.deltaTime * -30f, Space.World);
				}
			}
			if (rotatePointLights)
			{
				rotatingPointLights.transform.Rotate(Vector3.up * 50f * Time.deltaTime, Space.World);
			}
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				{
					SetStyle(--style);
				}
				else
				{
					SetStyle(++style);
				}
			}
			if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
			{
				SetStyle(0);
			}
			if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
			{
				SetStyle(1);
			}
			if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
			{
				SetStyle(2);
			}
			if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
			{
				SetStyle(3);
			}
			if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
			{
				SetStyle(4);
			}
			if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
			{
				SetStyle(5);
			}
			if (Input.GetKeyDown(KeyCode.H))
			{
				canvas.enabled = !canvas.enabled;
			}
		}

		public void SetAmbience(int index)
		{
			Ambience[] array = ambiences;
			GameObject[] activate;
			for (int i = 0; i < array.Length; i++)
			{
				activate = array[i].activate;
				for (int j = 0; j < activate.Length; j++)
				{
					activate[j].SetActive(value: false);
				}
			}
			amb = index % ambiences.Length;
			Ambience ambience = ambiences[amb];
			activate = ambience.activate;
			for (int i = 0; i < activate.Length; i++)
			{
				activate[i].SetActive(value: true);
			}
			RenderSettings.skybox = ambience.skybox;
			DynamicGI.UpdateEnvironment();
			for (int k = 0; k < ambiencesButtons.Length; k++)
			{
				ColorBlock colors = ambiencesButtons[k].colors;
				colors.colorMultiplier = ((k == index) ? 0.96f : 0.6f);
				ambiencesButtons[k].colors = colors;
			}
		}

		public void SetStyle(int index)
		{
			if (index < 0)
			{
				index = styles.Length - 1;
			}
			if (index >= styles.Length)
			{
				index = 0;
			}
			style = index;
			ShaderStyle.CharacterSettings[] settings = styles[style].settings;
			foreach (ShaderStyle.CharacterSettings characterSettings in settings)
			{
				Renderer[] renderers = characterSettings.renderers;
				for (int j = 0; j < renderers.Length; j++)
				{
					renderers[j].sharedMaterial = characterSettings.material;
				}
			}
			for (int k = 0; k < stylesButtons.Length; k++)
			{
				ColorBlock colors = stylesButtons[k].colors;
				colors.colorMultiplier = ((k == index) ? 0.96f : 0.6f);
				stylesButtons[k].colors = colors;
			}
		}

		public void SetFlat(bool flat)
		{
			float normalizedTime;
			if (!unityChanCopyright.activeInHierarchy)
			{
				Animation obj = catAnimation[(!flat) ? 1u : 0u];
				normalizedTime = obj[obj.clip.name].normalizedTime;
			}
			else
			{
				Animation obj2 = unityChanAnimation[(!flat) ? 1u : 0u];
				normalizedTime = obj2[obj2.clip.name].normalizedTime;
			}
			shadedGroup.SetActive(!flat);
			flatGroup.SetActive(flat);
			PlayCurrentAnimation(normalizedTime);
			for (int i = 0; i < textureButtons.Length; i++)
			{
				ColorBlock colors = textureButtons[i].colors;
				colors.colorMultiplier = (((i == 1 && flat) || (i == 0 && !flat)) ? 0.96f : 0.6f);
				textureButtons[i].colors = colors;
			}
		}

		public void SetCat(bool cat)
		{
			GameObject[] array = cats;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(cat);
			}
			array = unityChans;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(!cat);
			}
			if (unityChanDirLight != null)
			{
				unityChanDirLight.gameObject.SetActive(!cat);
			}
			if (catDirLight != null)
			{
				catDirLight.gameObject.SetActive(cat);
			}
			unityChanCopyright.SetActive(!cat);
			PlayCurrentAnimation();
			for (int j = 0; j < characterButtons.Length; j++)
			{
				ColorBlock colors = characterButtons[j].colors;
				colors.colorMultiplier = (((j == 0 && cat) || (j == 1 && !cat)) ? 0.96f : 0.6f);
				characterButtons[j].colors = colors;
			}
		}

		public void SetLightShadows(bool on)
		{
			Light[] array = dirLights;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].shadows = (on ? LightShadows.Soft : LightShadows.None);
			}
			array = otherLights;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].shadows = (on ? LightShadows.Soft : LightShadows.None);
			}
		}

		public void SetAnimation(int index)
		{
			catAnim = index;
			if (catAnim >= catAnimations.Length)
			{
				catAnim = 0;
			}
			if (catAnim < 0)
			{
				catAnim = catAnimations.Length - 1;
			}
			Animation[] array = catAnimation;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].clip = catAnimations[index];
			}
			uchanAnim = index;
			if (uchanAnim >= unityChanAnimations.Length)
			{
				uchanAnim = 0;
			}
			if (uchanAnim < 0)
			{
				uchanAnim = unityChanAnimations.Length - 1;
			}
			array = unityChanAnimation;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].clip = unityChanAnimations[index];
			}
			PlayCurrentAnimation();
			for (int j = 0; j < animationButtons.Length; j++)
			{
				ColorBlock colors = animationButtons[j].colors;
				colors.colorMultiplier = ((j == index) ? 0.96f : 0.6f);
				animationButtons[j].colors = colors;
			}
		}

		public void SetAnimationSpeed(float speed)
		{
			playingSpeed = speed;
			UpdateAnimSpeed();
		}

		public void PauseUnpauseAnimation(bool play)
		{
			animationPaused = !play;
			UpdateAnimSpeed();
		}

		private void UpdateAnimSpeed()
		{
			Animation[] array = catAnimation;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (AnimationState item in array[i])
				{
					item.speed = (animationPaused ? 0f : playingSpeed);
				}
			}
			array = unityChanAnimation;
			for (int i = 0; i < array.Length; i++)
			{
				foreach (AnimationState item2 in array[i])
				{
					item2.speed = (animationPaused ? 0f : playingSpeed);
				}
			}
		}

		private void PlayCurrentAnimation(float time = -1f)
		{
			bool num = !unityChanCopyright.activeInHierarchy;
			bool activeSelf = flatGroup.activeSelf;
			if (num)
			{
				Animation animation = catAnimation[activeSelf ? 1 : 0];
				animation.Play();
				if (time >= 0f)
				{
					animation[animation.clip.name].normalizedTime = time;
				}
				return;
			}
			Animation animation2 = unityChanAnimation[activeSelf ? 1 : 0];
			animation2.Play();
			if (time >= 0f)
			{
				animation2[animation2.clip.name].normalizedTime = time;
			}
			animation2 = unityChanAnimation[2];
			animation2.Play();
			if (time >= 0f)
			{
				animation2[animation2.clip.name].normalizedTime = time;
			}
		}
	}
}
