using System.Collections.Generic;
using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class MultiGridManager : MonoBehaviour
	{
		public delegate void OnActiveGridChangedDelegate(EasyGridBuilderPro activeGridSystem);

		[Tooltip("Simply select the 'Grid Surface' Layer Mask")]
		public LayerMask mouseColliderLayerMask;

		[HideInInspector]
		public List<EasyGridBuilderPro> easyGridBuilderProList = new List<EasyGridBuilderPro>();

		[HideInInspector]
		public EasyGridBuilderPro activeGridSystem;

		[HideInInspector]
		public bool onGrid;

		public static MultiGridManager Instance { get; private set; }

		public event OnActiveGridChangedDelegate OnActiveGridChanged;

		private void Awake()
		{
			Instance = this;
			EasyGridBuilderPro[] array = Object.FindObjectsOfType<EasyGridBuilderPro>();
			foreach (EasyGridBuilderPro item in array)
			{
				easyGridBuilderProList.Add(item);
			}
			if (easyGridBuilderProList.Count <= 0)
			{
				Debug.Log("<color=Red>Grid objects not found - Multi Grid Manager</color>");
				return;
			}
			activeGridSystem = easyGridBuilderProList[0];
			this.OnActiveGridChanged?.Invoke(activeGridSystem);
		}

		private void Update()
		{
			if (easyGridBuilderProList.Count <= 0)
			{
				Debug.Log("<color=Red>Grid objects not found - Multi Grid Manager</color>");
			}
			else if (activeGridSystem != GetUsingGrid())
			{
				activeGridSystem = GetUsingGrid();
				this.OnActiveGridChanged?.Invoke(activeGridSystem);
			}
		}

		private EasyGridBuilderPro GetUsingGrid()
		{
			Collider mouseWorldPositionCollider3D = GetMouseWorldPositionCollider3D();
			if ((bool)mouseWorldPositionCollider3D)
			{
				if ((bool)mouseWorldPositionCollider3D.gameObject.GetComponent<EasyGridBuilderPro>())
				{
					onGrid = true;
					foreach (EasyGridBuilderPro easyGridBuilderPro in easyGridBuilderProList)
					{
						if (mouseWorldPositionCollider3D.gameObject.GetComponent<EasyGridBuilderPro>() == easyGridBuilderPro)
						{
							return easyGridBuilderPro;
						}
					}
					if ((bool)activeGridSystem)
					{
						return activeGridSystem;
					}
					return easyGridBuilderProList[0];
				}
				onGrid = false;
				if ((bool)activeGridSystem)
				{
					return activeGridSystem;
				}
				return easyGridBuilderProList[0];
			}
			onGrid = false;
			if ((bool)activeGridSystem)
			{
				return activeGridSystem;
			}
			return easyGridBuilderProList[0];
		}

		private Collider GetMouseWorldPositionCollider3D()
		{
			using (List<EasyGridBuilderPro>.Enumerator enumerator = easyGridBuilderProList.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					EasyGridBuilderPro current = enumerator.Current;
					if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, 999f, current.mouseColliderLayerMask))
					{
						return hitInfo.collider;
					}
					return null;
				}
			}
			return null;
		}
	}
}
