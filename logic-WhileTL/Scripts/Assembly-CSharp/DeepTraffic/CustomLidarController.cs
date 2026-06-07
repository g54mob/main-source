using System;
using System.Collections.Generic;
using App.Data;
using ReinforcementLearning.Environment;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DeepTraffic
{
	public class CustomLidarController : ActiveComponent
	{
		private CarQuest cq;

		[SceneBind("LidarGrid/Grid")]
		private RectTransform lidarGrid;

		[SceneBind("LidarGrid/Grid/CarImage")]
		private Transform carImageTransform;

		[SceneBind("LanesLidarHolder")]
		private RectTransform lanesLidarHolderTransform;

		[SceneBind("FrontLidarHolder")]
		private RectTransform frontLidarHolderTransform;

		[SceneBind("BehindLidarHolder")]
		private RectTransform behindLidarHolderTransform;

		[SceneBind("BaseBlock")]
		private BaseBlockScrollbarController baseBlockController;

		private LidarBinarySwitch[] cells;

		private LidarBinarySwitch[,] allCells;

		private GameObject lidarCellPrefab;

		private Action<DeepTrafficEnvPresets> drawLidar;

		private Dictionary<Transform, GameObject> iconByHolder = new Dictionary<Transform, GameObject>();

		private int width = 7;

		private int height = 20;

		private float xStep;

		private float yStep;

		private float xInit;

		private float yInit;

		private Vector3[] corners = new Vector3[4];

		private Rect frontLidarRect;

		private Rect lanesLidarRect;

		private Rect behindLidarRect;

		private int yCarPos => height / 2;

		private int xCarPos => width / 2;

		public override void Init()
		{
			throw new NotImplementedException("Use Init(CarQuest)");
		}

		private void FullRedrawLidar()
		{
			drawLidar(cq.CarEnv);
			DisableCells();
			InitCells();
		}

		private void DisableCells()
		{
			if (cells != null)
			{
				LidarBinarySwitch[] array = cells;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Interactable = false;
				}
			}
		}

		private void DestroyCells()
		{
			cells = null;
			if (allCells != null)
			{
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < height; j++)
					{
						if (allCells[j, i] != null)
						{
							UnityEngine.Object.DestroyObject(allCells[j, i].gameObject);
						}
					}
				}
			}
			allCells = null;
		}

		public void CellSwitchAction(int i)
		{
			if (cells[i].SwitcherState == 1)
			{
				cq.CarEnv.enabledCount++;
				cq.CarEnv.enabledLidarCells[i] = true;
			}
			else
			{
				cq.CarEnv.enabledCount--;
				cq.CarEnv.enabledLidarCells[i] = false;
			}
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			drawLidar(null);
		}

		private void DropLidar(PointerEventData eventData, Transform lidarHolder, out LidarData envLidar, Action setNullLidar)
		{
			DragController[] componentsInChildren = lidarHolder.GetComponentsInChildren<DragController>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyObject(componentsInChildren[i].gameObject);
			}
			GameObject obj = eventData.pointerDrag;
			obj.transform.SetParent(lidarHolder, worldPositionStays: false);
			obj.transform.localPosition = Vector3.zero;
			iconByHolder[lidarHolder].SetActive(value: false);
			obj.GetComponent<DragController>().beginDragAction = delegate
			{
				obj.transform.SetParent(base.transform, worldPositionStays: true);
				iconByHolder[lidarHolder].SetActive(value: true);
				setNullLidar();
				FullRedrawLidar();
				ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_BlockFromList");
			};
			envLidar = obj.GetComponent<LidarBlockController>().LidarData;
		}

		private void EndDragLidar(PointerEventData eventData)
		{
			Vector3 point = Camera.main.ScreenToWorldPoint(eventData.position);
			if (frontLidarRect.Contains(point))
			{
				DropLidar(eventData, frontLidarHolderTransform, out cq.CarEnv.aheadLidar, delegate
				{
					cq.CarEnv.aheadLidar = null;
					cq.CarEnv.SetDefaultLidars();
				});
			}
			else if (lanesLidarRect.Contains(point))
			{
				DropLidar(eventData, lanesLidarHolderTransform, out cq.CarEnv.lanesLidar, delegate
				{
					cq.CarEnv.lanesLidar = null;
					cq.CarEnv.SetDefaultLidars();
				});
			}
			else
			{
				if (!behindLidarRect.Contains(point))
				{
					UnityEngine.Object.DestroyObject(eventData.pointerDrag);
					return;
				}
				DropLidar(eventData, behindLidarHolderTransform, out cq.CarEnv.behindLidar, delegate
				{
					cq.CarEnv.behindLidar = null;
					cq.CarEnv.SetDefaultLidars();
				});
			}
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_Block_Install");
			eventData.pointerDrag.transform.localPosition = Vector3.zero;
			cq.CarEnv.SetDefaultLidars();
			FullRedrawLidar();
		}

		private void InitBaseBlock()
		{
			baseBlockController.Init();
			foreach (LidarData lidarDatum in ActiveComponent._staticData.LidarData)
			{
				if (UnlockGroup.IsUnlocked(Logic.ParseReqGroups(lidarDatum.ReqUnlock)))
				{
					LidarBlockController lidarBlockController = Resources.Load<LidarBlockController>("Prefabs/" + lidarDatum.KeyName);
					baseBlockController.AddObject(lidarBlockController.gameObject, lidarDatum.KeyName, EndDragLidar);
				}
			}
		}

		private void InitLidar(Transform holder, ref LidarData envLidar, Action setNullLidar)
		{
			if (envLidar == null)
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>("Prefabs/" + envLidar.KeyName);
			if (!(gameObject == null))
			{
				GameObject obj = UnityEngine.Object.Instantiate(gameObject, holder);
				obj.GetComponent<LidarBlockController>().Init(envLidar.KeyName);
				iconByHolder[holder].SetActive(value: false);
				obj.transform.localPosition = Vector3.zero;
				DragController component = obj.GetComponent<DragController>();
				component.beginDragAction = delegate
				{
					obj.transform.SetParent(base.transform, worldPositionStays: true);
					iconByHolder[holder].SetActive(value: true);
					setNullLidar();
					FullRedrawLidar();
					ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_BlockFromList");
				};
				component.endDragAction = EndDragLidar;
			}
		}

		private void InitLidars()
		{
			DragController[] componentsInChildren = frontLidarHolderTransform.GetComponentsInChildren<DragController>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyObject(componentsInChildren[i].gameObject);
			}
			componentsInChildren = behindLidarHolderTransform.GetComponentsInChildren<DragController>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyObject(componentsInChildren[i].gameObject);
			}
			componentsInChildren = lanesLidarHolderTransform.GetComponentsInChildren<DragController>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyObject(componentsInChildren[i].gameObject);
			}
			InitLidar(frontLidarHolderTransform, ref cq.CarEnv.aheadLidar, delegate
			{
				cq.CarEnv.aheadLidar = null;
				cq.CarEnv.SetDefaultLidars();
			});
			if (cq.CarEnv.maxLanesSide > 0)
			{
				lanesLidarHolderTransform.gameObject.SetActive(value: true);
				InitLidar(lanesLidarHolderTransform, ref cq.CarEnv.lanesLidar, delegate
				{
					cq.CarEnv.lanesLidar = null;
					cq.CarEnv.SetDefaultLidars();
				});
			}
			else
			{
				lanesLidarHolderTransform.gameObject.SetActive(value: false);
			}
			if (cq.CarEnv.maxPatchesBehind > 5)
			{
				behindLidarHolderTransform.gameObject.SetActive(value: true);
				InitLidar(behindLidarHolderTransform, ref cq.CarEnv.behindLidar, delegate
				{
					cq.CarEnv.behindLidar = null;
					cq.CarEnv.SetDefaultLidars();
				});
			}
			behindLidarHolderTransform.gameObject.SetActive(value: false);
			lanesLidarHolderTransform.gameObject.SetActive(value: false);
			frontLidarHolderTransform.gameObject.SetActive(value: false);
		}

		private void CalculateLidarRect(RectTransform transform, out Rect rect)
		{
			transform.GetWorldCorners(corners);
			float x = corners[2].x - corners[0].x;
			float y = corners[2].y - corners[0].y;
			rect = new Rect(transform.position - new Vector3(x, y, 0f) / 2f, new Vector2(x, y));
		}

		private void CalculateLidarRects()
		{
			CalculateLidarRect(frontLidarHolderTransform, out frontLidarRect);
			CalculateLidarRect(lanesLidarHolderTransform, out lanesLidarRect);
			CalculateLidarRect(behindLidarHolderTransform, out behindLidarRect);
		}

		private void InitCells()
		{
			cells = new LidarBinarySwitch[DeepTrafficStatic.InputSize(cq.CarEnv)];
			int num = DeepTrafficStatic.BehindLidarBound(cq.CarEnv);
			int num2 = DeepTrafficStatic.FrontLidarBound(cq.CarEnv);
			int num3 = xCarPos - cq.CarEnv.LanesSide;
			int num4 = yCarPos - cq.CarEnv.PatchesBehind + 1;
			for (int i = 0; i < num; i++)
			{
				cells[i] = allCells[num4 + i / (2 * cq.CarEnv.LanesSide), num3 + i % (2 * cq.CarEnv.LanesSide + 1)];
			}
			num4 = yCarPos - cq.CarEnv.carHeight;
			for (int j = num; j < num2; j++)
			{
				int num5 = j - num;
				int num6 = 2 * cq.CarEnv.LanesSide;
				cells[j] = allCells[num4 + num5 / num6, num3 + num5 % num6 + ((num5 % num6 >= cq.CarEnv.LanesSide) ? 1 : 0)];
			}
			num4 = yCarPos;
			for (int k = num2; k < cells.Length; k++)
			{
				int num7 = k - num2;
				int num8 = 2 * cq.CarEnv.LanesSide + 1;
				cells[k] = allCells[num4 + num7 / num8, num3 + num7 % num8];
			}
			for (int l = 0; l < cells.Length; l++)
			{
				cells[l].Init(cq.CarEnv.enabledLidarCells[l] ? 1 : 0);
				int iCopy = l;
				cells[l].switchAction = delegate
				{
					CellSwitchAction(iCopy);
				};
				cells[l].Interactable = true;
			}
			drawLidar(null);
		}

		private void InitGrid()
		{
			xStep = lidarGrid.rect.width / (float)width;
			yStep = lidarGrid.rect.height / (float)height;
			xInit = (0f - xStep) * (float)(width - 1) / 2f;
			yInit = (0f - yStep) * (float)(height - 1) / 2f;
			int num = yCarPos - cq.CarEnv.maxPatchesBehind;
			int num2 = yCarPos + cq.CarEnv.maxPatchesAhead - 1;
			int num3 = xCarPos - cq.CarEnv.maxLanesSide;
			int num4 = xCarPos + cq.CarEnv.maxLanesSide;
			allCells = new LidarBinarySwitch[height, width];
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					if (j != xCarPos || i >= yCarPos || i < yCarPos - cq.CarEnv.carHeight)
					{
						allCells[i, j] = UnityEngine.Object.Instantiate(lidarCellPrefab, lidarGrid.transform).GetComponent<LidarBinarySwitch>();
						allCells[i, j].Init(0);
						allCells[i, j].transform.localPosition = GetCellCenter(j, i);
						allCells[i, j].Interactable = false;
					}
				}
			}
			Vector3 cellCenter = GetCellCenter(xCarPos, yCarPos - (cq.CarEnv.carHeight + 1) / 2);
			carImageTransform.localPosition = cellCenter;
		}

		private Vector3 GetCellCenter(int x, int y)
		{
			return new Vector3(xInit + (float)x * xStep, yInit + (float)y * yStep, 0f);
		}

		private Vector3 GetCellCenter(float x, float y)
		{
			return new Vector3(xInit + x * xStep, yInit + y * yStep, 0f);
		}

		public void Init(CarQuest cq, Action<DeepTrafficEnvPresets> drawLidar)
		{
			base.Init();
			this.cq = cq;
			this.drawLidar = drawLidar;
			DestroyCells();
			InitGrid();
			CalculateLidarRects();
			InitLidars();
			InitBaseBlock();
			InitCells();
		}

		protected override void OnInit()
		{
			base.OnInit();
			SceneBindContainer.BindObjects(this, base.transform);
			lidarCellPrefab = Resources.Load<GameObject>("Prefabs/LidarBlock");
			DragController[] componentsInChildren = frontLidarHolderTransform.GetComponentsInChildren<DragController>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyObject(componentsInChildren[i].gameObject);
			}
			componentsInChildren = behindLidarHolderTransform.GetComponentsInChildren<DragController>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyObject(componentsInChildren[i].gameObject);
			}
			componentsInChildren = lanesLidarHolderTransform.GetComponentsInChildren<DragController>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				UnityEngine.Object.DestroyObject(componentsInChildren[i].gameObject);
			}
			iconByHolder.Clear();
			iconByHolder[frontLidarHolderTransform] = frontLidarHolderTransform.GetComponentsInChildren<Image>()[1].gameObject;
			iconByHolder[behindLidarHolderTransform] = behindLidarHolderTransform.GetComponentsInChildren<Image>()[1].gameObject;
			iconByHolder[lanesLidarHolderTransform] = lanesLidarHolderTransform.GetComponentsInChildren<Image>()[1].gameObject;
		}
	}
}
