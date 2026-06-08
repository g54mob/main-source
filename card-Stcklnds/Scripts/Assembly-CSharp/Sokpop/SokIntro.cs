using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Sokpop
{
	public class SokIntro : MonoBehaviour
	{
		public string NextSceneName;

		public Material PostProcessMat;

		public List<Sprite> SokSprites;

		public List<Sprite> HaarSprites;

		public List<AudioClip> SokpopSounds;

		public AudioClip Horn;

		public Image SokImage;

		public Image HaarImage;

		public Text SokText;

		public Text PopText;

		private AudioSource audioSource;

		private bool sok;

		private bool pop;

		private float angleRot;

		private float anglePlus;

		private float image_angle;

		private float image_xscale;

		private float image_yscale;

		private float scale;

		private float scaleTarg;

		private float t1;

		private float t2;

		private float haarRot;

		private float haarPlus;

		private float haar_xscale;

		private float haar_yscale;

		private int timer;

		private float image_index;

		private int popTimer;

		private int drawTimer;

		private float overgangRadius;

		private float fakeTimer;

		private void Awake()
		{
			Application.targetFrameRate = 60;
			if ((from s in Environment.GetCommandLineArgs()
				select s.ToLower()).Contains("--no-intro"))
			{
				SceneManager.LoadScene(NextSceneName);
			}
			Draw();
			overgangRadius = 1.5f;
		}

		private void Start()
		{
			audioSource = GetComponent<AudioSource>();
			scaleTarg = 1f;
			anglePlus = 5f;
		}

		private void Update()
		{
			InputSystem.Update();
			if (Keyboard.current.escapeKey.wasPressedThisFrame)
			{
				SceneManager.LoadScene(NextSceneName);
			}
		}

		private void FixedUpdate()
		{
			fakeTimer += Time.deltaTime;
			while (fakeTimer >= 1f / 60f)
			{
				FakeUpdate();
				fakeTimer -= 1f / 60f;
			}
		}

		private void FakeUpdate()
		{
			Draw();
			drawTimer++;
			if (drawTimer < 20)
			{
				return;
			}
			if (drawTimer == 20)
			{
				audioSource.PlayOneShot(Horn);
			}
			angleRot += anglePlus * 3f + 8f;
			anglePlus *= 0.95f;
			angleRot %= 360f;
			image_angle = lengthdir_x(10f * anglePlus, angleRot) - 10f;
			scale += (scaleTarg - scale) * 0.15f;
			image_xscale = (1f + lengthdir_x(0.1f * anglePlus, angleRot)) * scale;
			image_yscale = (1f + lengthdir_y(0.1f * anglePlus, angleRot + 30f)) * scale;
			if (anglePlus < 0.4f && !sok)
			{
				audioSource.PlayOneShot(SokpopSounds[UnityEngine.Random.Range(0, SokpopSounds.Count)]);
				sok = true;
			}
			if (sok)
			{
				popTimer++;
				if (popTimer > 32)
				{
					pop = true;
				}
			}
			if (sok && t1 < (float)"sok".Length)
			{
				t1 += 0.333334f;
			}
			if (pop && t2 < (float)"pop".Length)
			{
				t2 += 0.333334f;
			}
			haar_xscale = (1f + lengthdir_x(0.11f * anglePlus, angleRot - 30f)) * scale;
			haar_yscale = (1f + lengthdir_y(0.11f * anglePlus, angleRot - 10f)) * scale;
			timer++;
			if (timer > 120)
			{
				overgangRadius -= 0.02f;
				if (overgangRadius < 0f)
				{
					SceneManager.LoadScene(NextSceneName);
				}
			}
			image_index += 0.1f;
		}

		private void Draw()
		{
			SokText.text = "sok".Substring(0, Mathf.FloorToInt(t1));
			PopText.text = "pop".Substring(0, Mathf.FloorToInt(t2));
			SokImage.transform.localScale = new Vector3(image_xscale, image_yscale, 1f);
			SokImage.transform.localEulerAngles = new Vector3(0f, 0f, image_angle);
			HaarImage.transform.localScale = new Vector3(haar_xscale, haar_yscale, 1f);
			HaarImage.transform.localEulerAngles = new Vector3(0f, 0f, image_angle);
			SokImage.sprite = SokSprites[Mathf.FloorToInt(image_index) % SokSprites.Count];
			HaarImage.sprite = HaarSprites[Mathf.FloorToInt(image_index) % HaarSprites.Count];
		}

		private float lengthdir_x(float len, float dir)
		{
			return len * Mathf.Cos(MathF.PI / 180f * dir);
		}

		private float lengthdir_y(float len, float dir)
		{
			return len * Mathf.Sin(MathF.PI / 180f * dir);
		}

		public void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			PostProcessMat.SetFloat("_CircleSize", overgangRadius);
			Graphics.Blit(source, destination, PostProcessMat);
		}
	}
}
