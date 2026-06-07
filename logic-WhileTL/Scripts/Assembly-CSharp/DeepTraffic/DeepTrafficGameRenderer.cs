using System;
using ReinforcementLearning.Environment;
using UnityEngine;

namespace DeepTraffic
{
	public class DeepTrafficGameRenderer : ActiveComponent
	{
		public DeepTrafficEnvironment env;

		[SceneBind("RoadSprite")]
		private ScrollController roadController;

		[SceneBind("RoadSpritePS")]
		private RectTransform roadPS;

		[SceneBind("RoadSprite")]
		private RectTransform roadTransform;

		[SceneBind("LeftRoadEvalBoard")]
		private ScrollController leftEvalBoardController;

		[SceneBind("RightRoadEvalBoard")]
		private ScrollController rightEvalBoardController;

		[SceneBind("PlayerCar")]
		private Transform playerCarTransform;

		[SceneBind("LeftRoadBoard")]
		private Transform leftRoadBoardTransform;

		[SceneBind("RightRoadBoard")]
		private Transform rightRoadBoardTransform;

		[SceneBind("HiddenRoadSprite")]
		private Transform hiddenRoadSpriteTransform;

		[SceneBind("CarAI")]
		private CarAI carAI;

		private RectTransform[] dummyCarTransforms;

		private RectTransform[] lidarBlockTransforms;

		private RectTransform[] lineStartTransforms;

		private RectTransform[] brakeTrackTransforms;

		private float xStep;

		private float yStep;

		private float xInit;

		private float yInit;

		private bool started;

		private static int xLidarScale = 1;

		private static int yLidarScale = 1;

		private DeepTrafficRunMode runMode;

		private System.Random random;

		private Color carLedarColor;

		private Color freeLedarColor;

		private static Vector3[] corners1 = new Vector3[4];

		private static Vector3[] corners2 = new Vector3[4];

		private float scrollSpeed;

		private static Sprite roadOpenSprite;

		private static Sprite roadOpenEvalSprite;

		private SpriteRenderer roadSpriteRenderer;

		private float scrollAcc;

		public float HiddenRoadWidth { get; private set; }

		public Vector3 HiddenRoadPosition => hiddenRoadSpriteTransform.position;

		private Vector3 GetCellCenter(int x, int y)
		{
			return new Vector3(xInit + (float)x * xStep, yInit + (float)y * yStep, 0f);
		}

		private Vector3 GetCellCenter(float x, float y)
		{
			return new Vector3(xInit + x * xStep, yInit + y * yStep, 0f);
		}

		private Vector3 GetCellCenter(int x, int y, float xScale, float yScale)
		{
			float num = xStep / xScale;
			float num2 = yStep / yScale;
			float num3 = (0f - num) * ((float)env.presets.width * xScale - 1f) / 2f;
			float num4 = (0f - num2) * ((float)env.presets.height * yScale - 1f) / 2f;
			return new Vector3(num3 + (float)x * num, num4 + (float)y * num2, 0f);
		}

		public void InitLidars(DeepTrafficEnvPresets presets)
		{
			if (lidarBlockTransforms != null)
			{
				RectTransform[] array = lidarBlockTransforms;
				for (int i = 0; i < array.Length; i++)
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
			}
			if (roadTransform == null)
			{
				roadController = GameObject.Find("RoadSprite").GetComponent<ScrollController>();
				roadSpriteRenderer = roadController.gameObject.GetComponent<SpriteRenderer>();
				roadTransform = roadController.gameObject.GetComponent<RectTransform>();
			}
			lidarBlockTransforms = new RectTransform[DeepTrafficStatic.InputSize(presets) * xLidarScale * yLidarScale];
			GameObject gameObject = Resources.Load<GameObject>("Prefabs/LedarBlock");
			RectTransform component = gameObject.GetComponent<RectTransform>();
			Vector3 localScale = new Vector3(roadTransform.rect.width * roadTransform.localScale.x / (component.rect.width * (float)presets.width * (float)xLidarScale), roadTransform.rect.height * roadTransform.localScale.y / (component.rect.height * (float)presets.height * (float)yLidarScale), 1f);
			component.localScale = localScale;
			for (int j = 0; j < lidarBlockTransforms.Length; j++)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, base.gameObject.GetComponent<Transform>());
				lidarBlockTransforms[j] = gameObject2.GetComponent<RectTransform>();
			}
		}

		private void InstantiatePrefabs()
		{
			if (dummyCarTransforms != null)
			{
				RectTransform[] array = dummyCarTransforms;
				for (int i = 0; i < array.Length; i++)
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
			}
			if (lineStartTransforms != null)
			{
				RectTransform[] array = lineStartTransforms;
				for (int i = 0; i < array.Length; i++)
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
			}
			if (brakeTrackTransforms != null)
			{
				RectTransform[] array = brakeTrackTransforms;
				foreach (RectTransform rectTransform in array)
				{
					if (rectTransform != null)
					{
						UnityEngine.Object.Destroy(rectTransform.gameObject);
					}
				}
			}
			if (env.presets.carNumber > 0)
			{
				dummyCarTransforms = new RectTransform[env.presets.carNumber];
				lineStartTransforms = new RectTransform[env.presets.carNumber + 1];
				brakeTrackTransforms = new RectTransform[env.presets.width];
				GameObject original = Resources.Load<GameObject>("Prefabs/DummyCar");
				GameObject original2 = Resources.Load<GameObject>("Prefabs/LineStart");
				for (int j = 0; j < env.presets.carNumber; j++)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(original, base.gameObject.transform);
					ChangeUIStateEnv componentInChildren = gameObject.GetComponentInChildren<ChangeUIStateEnv>();
					componentInChildren.Init();
					componentInChildren.Redraw(j);
					componentInChildren.transform.SetParent(playerCarTransform);
					componentInChildren.transform.localScale = Vector3.one;
					componentInChildren.transform.SetParent(gameObject.transform);
					dummyCarTransforms[j] = gameObject.GetComponent<RectTransform>();
				}
				for (int k = 0; k < env.presets.carNumber + 1; k++)
				{
					GameObject gameObject2 = UnityEngine.Object.Instantiate(original2, base.gameObject.transform);
					lineStartTransforms[k] = gameObject2.GetComponent<RectTransform>();
					lineStartTransforms[k].gameObject.SetActive(value: false);
				}
			}
			InitLidars(env.presets);
			roadController.GetComponent<RectTransform>();
			InitBrakeTrackPositions();
		}

		public void Init(DeepTrafficEnvironment env)
		{
			this.env = env;
			random = new System.Random(env.presets.width);
			env.RenderFunction = Render;
			if (!base.IsInited)
			{
				base.Init();
			}
			RenderRoad();
			InstantiatePrefabs();
			env.Render();
			SetUpLineStarts();
		}

		private Vector3 GenerateBrakeTrackPosition(RectTransform rectTransform, int line)
		{
			rectTransform.GetWorldCorners(corners1);
			float num = corners1[2].y - corners1[0].y;
			Vector3 cellCenter = GetCellCenter(line, (float)env.presets.height + 10f + (float)random.NextDouble() * 360f);
			cellCenter.y += num / (rectTransform.lossyScale.y * 2f) * rectTransform.localScale.y;
			return cellCenter;
		}

		private Vector3 GenerateBrakeTrackScale()
		{
			return new Vector3(5f, Mathf.Max(1f, random.SampleNormal(5f, 2f)), 1f);
		}

		private void InitBrakeTrackPositions()
		{
			GameObject original = Resources.Load<GameObject>("Prefabs/brakeTrack");
			for (int i = 0; i < env.presets.width; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(original, base.gameObject.transform);
				brakeTrackTransforms[i] = gameObject.GetComponent<RectTransform>();
				brakeTrackTransforms[i].localScale = GenerateBrakeTrackScale();
				brakeTrackTransforms[i].localPosition = GenerateBrakeTrackPosition(brakeTrackTransforms[i], i);
			}
		}

		public void SetUpLineStarts()
		{
			for (int i = 0; i < dummyCarTransforms.Length; i++)
			{
				if (!dummyCarTransforms[i].gameObject.activeSelf)
				{
					lineStartTransforms[i].gameObject.SetActive(value: false);
					continue;
				}
				Car car = env.FullState.dummyCars[i];
				Vector3 cellCenter = GetCellCenter(car.x, car.y + 1);
				lineStartTransforms[i].localPosition = cellCenter;
			}
			lineStartTransforms[lineStartTransforms.Length - 1].localPosition = GetCellCenter(env.FullState.player.x, env.FullState.player.y + 1);
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
			if (roadController == null)
			{
				roadController = GameObject.Find("RoadSprite").transform.GetComponent<ScrollController>();
			}
			roadController.Init();
			leftEvalBoardController.Init();
			leftEvalBoardController.speedScale = roadController.speedScale / 2f;
			carAI.Init();
			carLedarColor = Logic.GetColor("RED", 82);
			freeLedarColor = Logic.GetColor("LEDAR_FREE", 82);
			roadOpenSprite = Logic.LoadSprite("Road_open");
			roadOpenEvalSprite = Logic.LoadSprite("Road_open_eval");
			roadSpriteRenderer = roadController.GetComponent<SpriteRenderer>();
			leftEvalBoardController.gameObject.SetActive(value: false);
			rightEvalBoardController.gameObject.SetActive(value: false);
		}

		private void Render(DeepTrafficState state)
		{
			RenderCar(state.player, playerCarTransform);
			for (int i = 0; i < env.presets.carNumber; i++)
			{
				RenderCar(state.dummyCars[i], dummyCarTransforms[i]);
			}
			ColorLidar(state);
		}

		public void ColorLidar(DeepTrafficState state)
		{
			for (int i = 0; i < lidarBlockTransforms.Length; i++)
			{
				bool flag = false;
				RectTransform[] array = dummyCarTransforms;
				foreach (RectTransform rectTransform in array)
				{
					if (rectTransform.gameObject.activeSelf && RectOverlaps(rectTransform, lidarBlockTransforms[i]))
					{
						flag = true;
						break;
					}
				}
				lidarBlockTransforms[i].GetComponent<SpriteRenderer>().color = (flag ? carLedarColor : freeLedarColor);
			}
		}

		public static bool RectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
		{
			rectTrans1.GetWorldCorners(corners1);
			rectTrans2.GetWorldCorners(corners2);
			Rect rect = new Rect(new Vector2(corners1[0].x, corners1[0].y), new Vector2(corners1[2].x - corners1[0].x, corners1[2].y - corners1[0].y));
			Rect other = new Rect(new Vector2(corners2[0].x, corners2[0].y), new Vector2(corners2[2].x - corners2[0].x, corners2[2].y - corners2[0].y));
			return rect.Overlaps(other);
		}

		private void RenderCar(Car car, Transform carTransform)
		{
			if (car.y < 0 || car.y > env.presets.height + env.presets.carHeight)
			{
				carTransform.gameObject.SetActive(value: false);
				return;
			}
			carTransform.gameObject.SetActive(value: true);
			Vector3 cellCenter = GetCellCenter(car.x, car.y);
			cellCenter.x += xStep * (float)car.xShift * (float)car.xDir / (float)env.presets.changeXThreshold;
			cellCenter.y -= yStep * (float)(env.presets.carHeight - 1) / 2f;
			cellCenter.y += (float)car.yShift / (float)env.presets.changeYThreshold * yStep;
			carTransform.localPosition = cellCenter;
			if (car.isPlayer)
			{
				carAI.HighlightGlobal = false;
				carAI.SetHelmRotate(car.xDir);
				if (car.xDir != 0)
				{
					carAI.HighlightHelm = true;
				}
				else if (car.speedDir > 0)
				{
					carAI.HighlightSpeedPedal = true;
				}
				else if (car.speedDir < 0)
				{
					carAI.HighlightPedalSel = true;
				}
				RenderLidar(car);
			}
		}

		public void RenderLidar(Car player, DeepTrafficEnvPresets presets = null)
		{
			DeepTrafficEnvPresets deepTrafficEnvPresets = presets;
			if (presets == null)
			{
				deepTrafficEnvPresets = env.presets;
			}
			int num = 0;
			for (int i = yLidarScale * (player.y - deepTrafficEnvPresets.PatchesBehind + 1); i < yLidarScale * (player.y + deepTrafficEnvPresets.PatchesAhead + 1); i++)
			{
				for (int j = xLidarScale * (player.x - deepTrafficEnvPresets.LanesSide); j < xLidarScale * (player.x + deepTrafficEnvPresets.LanesSide + 1); j++)
				{
					if (((j < 0) ? (j - xLidarScale + 1) : j) / xLidarScale != player.x || i / yLidarScale < player.y - deepTrafficEnvPresets.carHeight + 1 || i / yLidarScale > player.y)
					{
						if ((deepTrafficEnvPresets.enabledLidarCells != null && !deepTrafficEnvPresets.enabledLidarCells[num]) || (float)j + (float)xLidarScale * (float)player.xShift * (float)player.xDir / (float)deepTrafficEnvPresets.changeXThreshold < 0f || (float)j + (float)xLidarScale * (float)player.xShift * (float)player.xDir / (float)deepTrafficEnvPresets.changeXThreshold > (float)(xLidarScale * deepTrafficEnvPresets.width - 1) || i < 0 || i > deepTrafficEnvPresets.height * yLidarScale - 1)
						{
							lidarBlockTransforms[num].gameObject.SetActive(value: false);
							num++;
							continue;
						}
						lidarBlockTransforms[num].gameObject.SetActive(value: true);
						Vector3 cellCenter = GetCellCenter(j, i, xLidarScale, yLidarScale);
						cellCenter.x += xStep * (float)player.xShift * (float)player.xDir / (float)deepTrafficEnvPresets.changeXThreshold;
						lidarBlockTransforms[num].localPosition = cellCenter;
						num++;
					}
				}
			}
		}

		private void RenderRoad()
		{
			if (roadController == null)
			{
				roadController = GameObject.Find("RoadSprite").GetComponent<ScrollController>();
				roadSpriteRenderer = roadController.gameObject.GetComponent<SpriteRenderer>();
			}
			roadController.transform.localScale = new Vector3((float)env.presets.width * hiddenRoadSpriteTransform.localScale.x / 8f, env.presets.height / 2, 1f);
			roadController.GetComponent<RectTransform>().GetWorldCorners(corners1);
			scrollSpeed = (corners1[2].y - corners1[0].y) * roadController.speedScale * 4f / (float)env.presets.height;
			roadController.GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", new Vector2(env.presets.width, env.presets.height / 4));
			leftEvalBoardController.GetComponent<Renderer>().sharedMaterial.SetTextureScale("_MainTex", new Vector2(1f, env.presets.height / 8));
			RectTransform component = roadController.GetComponent<RectTransform>();
			xStep = component.rect.width * component.localScale.x / (float)env.presets.width;
			yStep = component.rect.height * component.localScale.y / (float)env.presets.height;
			xInit = (0f - xStep) * (float)(env.presets.width - 1) / 2f;
			yInit = (0f - yStep) * (float)(env.presets.height - 1) / 2f;
			leftRoadBoardTransform.localScale = new Vector3(3f, env.presets.height / 2, 1f);
			rightRoadBoardTransform.localScale = new Vector3(3f, env.presets.height / 2, 1f);
			leftRoadBoardTransform.localPosition = GetCellCenter(-0.5f, (float)env.presets.height / 2f - 0.5f);
			rightRoadBoardTransform.localPosition = GetCellCenter((float)env.presets.width - 0.5f, (float)env.presets.height / 2f - 0.5f);
			leftEvalBoardController.transform.localScale = new Vector3(1.75f, env.presets.height / 2, 1f);
			rightEvalBoardController.transform.localScale = leftEvalBoardController.transform.localScale;
			leftEvalBoardController.transform.localPosition = GetCellCenter(-0.5f, (float)env.presets.height / 2f - 0.5f);
			rightEvalBoardController.transform.localPosition = GetCellCenter((float)env.presets.width - 0.5f, (float)env.presets.height / 2f - 0.5f);
			hiddenRoadSpriteTransform.GetComponent<RectTransform>().GetWorldCorners(corners1);
			HiddenRoadWidth = corners1[2].x - corners1[0].x;
		}

		public void SetRoadType(DeepTrafficRunMode runMode)
		{
			this.runMode = runMode;
			if (roadController == null)
			{
				roadController = GameObject.Find("RoadSprite").GetComponent<ScrollController>();
				roadSpriteRenderer = roadController.gameObject.GetComponent<SpriteRenderer>();
				roadTransform = roadController.gameObject.GetComponent<RectTransform>();
			}
			if (runMode == DeepTrafficRunMode.Test || runMode == DeepTrafficRunMode.Release)
			{
				roadSpriteRenderer.sprite = roadOpenEvalSprite;
				leftEvalBoardController.gameObject.SetActive(value: true);
				rightEvalBoardController.gameObject.SetActive(value: true);
				leftEvalBoardController.accSum = 0f;
				rightEvalBoardController.accSum = 0f;
				for (int i = 0; i < dummyCarTransforms.Length; i++)
				{
					if (dummyCarTransforms[i].gameObject.activeSelf)
					{
						lineStartTransforms[i].gameObject.SetActive(value: true);
					}
				}
				lineStartTransforms[lineStartTransforms.Length - 1].gameObject.SetActive(value: true);
				RectTransform[] array = brakeTrackTransforms;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].gameObject.SetActive(value: true);
				}
			}
			else
			{
				roadSpriteRenderer.sprite = roadOpenSprite;
				leftEvalBoardController.gameObject.SetActive(value: false);
				rightEvalBoardController.gameObject.SetActive(value: false);
				RectTransform[] array = lineStartTransforms;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].gameObject.SetActive(value: false);
				}
				array = brakeTrackTransforms;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].gameObject.SetActive(value: false);
				}
			}
		}

		public void FullStart(DeepTrafficRunMode runMode)
		{
			SetRoadType(runMode);
			scrollAcc = 0f;
			started = true;
		}

		private void Update()
		{
			if (!started)
			{
				return;
			}
			if (runMode == DeepTrafficRunMode.Test || runMode == DeepTrafficRunMode.Release)
			{
				RectTransform[] array = lineStartTransforms;
				foreach (RectTransform rectTransform in array)
				{
					if (rectTransform.localPosition.y < GetCellCenter(1, -1).y)
					{
						rectTransform.gameObject.SetActive(value: false);
						continue;
					}
					Vector3 position = rectTransform.position;
					position.y -= scrollAcc * scrollSpeed;
					rectTransform.position = position;
				}
				for (int j = 0; j < env.presets.width; j++)
				{
					RectTransform rectTransform2 = brakeTrackTransforms[j];
					roadTransform.GetWorldCorners(corners1);
					rectTransform2.GetWorldCorners(corners2);
					if (corners2[2].y < corners1[0].y)
					{
						rectTransform2.localScale = GenerateBrakeTrackScale();
						rectTransform2.localPosition = GenerateBrakeTrackPosition(rectTransform2, j);
					}
					Vector3 position2 = rectTransform2.position;
					position2.y -= scrollAcc * scrollSpeed;
					rectTransform2.position = position2;
				}
				scrollAcc = 0f;
			}
			env.Render();
		}

		public void OnEnd()
		{
			started = false;
			carAI.HighlightGlobal = false;
			carAI.SetHelmRotate(0);
		}

		public void AddToRoadSpeedList(float x)
		{
			roadController.accSum += x;
			leftEvalBoardController.accSum += x;
			scrollAcc += x;
		}
	}
}
