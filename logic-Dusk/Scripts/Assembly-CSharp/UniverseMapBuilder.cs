using System;
using System.Collections.Generic;
using UnityEngine;

public class UniverseMapBuilder : MonoBehaviour
{
	public Material TerminationNodeMat;

	public Material StartingNodeMat;

	public Material shortLineMat;

	public Material longLineMat;

	private bool isStepingThroughNodeBuilding = true;

	private bool enableStepThroughCameraCentering;

	private bool isHelpHidden;

	private UniverseMapManager universeMapManager;

	private GUIStyle helpGuiStyle = new GUIStyle();

	private void Awake()
	{
		universeMapManager = new UniverseMapManager(true, false)
		{
			NumberOfGalaxyNodes = 500,
			BreakDownDepth = 3,
			BreakDownChanceOf = 2,
			DistanceBetweenShortConnections = 100,
			DistanceBetweenLongConnections = 250,
			biasFactor = 10,
			maxShortConnections = 3,
			maxLongConnections = 1,
			reduceLongConnectionsFactor = 4
		};
		UniverseMapManager obj = universeMapManager;
		obj.StartingNodePlaced = (UniverseMapManager.NodePlaced)Delegate.Combine(obj.StartingNodePlaced, new UniverseMapManager.NodePlaced(StartingNodePlaced));
		UniverseMapManager obj2 = universeMapManager;
		obj2.TerminatingNodePlaced = (UniverseMapManager.NodePlaced)Delegate.Combine(obj2.TerminatingNodePlaced, new UniverseMapManager.NodePlaced(TerminatingNodePlaced));
		UniverseNode.ShortLineMat = shortLineMat;
		UniverseNode.LongLineMat = longLineMat;
		helpGuiStyle.normal.textColor = Color.white;
		helpGuiStyle.fontSize = 10;
		GenerateUniverseNodes();
	}

	private void StartingNodePlaced(UniverseNode node)
	{
		if (node.gameObject != null)
		{
			if (StartingNodeMat != null)
			{
				node.gameObject.GetComponent<Renderer>().material = StartingNodeMat;
			}
			node.gameObject.transform.localScale = new Vector3(node.gameObject.transform.localScale.x * 2f, node.gameObject.transform.localScale.y * 2f, node.gameObject.transform.localScale.z * 2f);
		}
	}

	private void TerminatingNodePlaced(UniverseNode node)
	{
		if (TerminationNodeMat != null)
		{
			node.gameObject.GetComponent<Renderer>().material = TerminationNodeMat;
		}
		node.gameObject.transform.localScale = new Vector3(node.gameObject.transform.localScale.x * 1.5f, node.gameObject.transform.localScale.y * 1.5f, node.gameObject.transform.localScale.z * 1.5f);
	}

	private void Update()
	{
		if (isStepingThroughNodeBuilding)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				List<UniverseNode> list = universeMapManager.BuildNextLayer();
				universeMapManager.EnableAllEdges();
				if (enableStepThroughCameraCentering)
				{
					universeMapManager.CenterCamera();
				}
				isStepingThroughNodeBuilding = !universeMapManager.AllLayersGenerated;
			}
			else if (Input.GetKeyDown(KeyCode.C))
			{
				enableStepThroughCameraCentering = !enableStepThroughCameraCentering;
			}
			else if (Input.GetKeyDown(KeyCode.X))
			{
				universeMapManager.BuildAllRemainingLayers();
				if (enableStepThroughCameraCentering)
				{
					universeMapManager.CenterCamera();
				}
				isStepingThroughNodeBuilding = false;
			}
		}
		else if (Input.GetKey(KeyCode.N))
		{
			if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
			{
				universeMapManager.NumberOfGalaxyNodes += 100;
				if (universeMapManager.NumberOfGalaxyNodes > 10000)
				{
					universeMapManager.NumberOfGalaxyNodes = 10000;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				universeMapManager.NumberOfGalaxyNodes -= 100;
				if (universeMapManager.NumberOfGalaxyNodes < 50)
				{
					universeMapManager.NumberOfGalaxyNodes = 50;
				}
			}
		}
		else if (Input.GetKey(KeyCode.B))
		{
			if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
			{
				universeMapManager.biasFactor += 5;
				if (universeMapManager.biasFactor > 50)
				{
					universeMapManager.biasFactor = 50;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				universeMapManager.biasFactor -= 5;
				if (universeMapManager.biasFactor < 0)
				{
					universeMapManager.biasFactor = 0;
				}
			}
		}
		else if (Input.GetKey(KeyCode.S))
		{
			if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
			{
				universeMapManager.maxShortConnections++;
				if (universeMapManager.maxShortConnections > 15)
				{
					universeMapManager.maxShortConnections = 15;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				universeMapManager.maxShortConnections--;
				if (universeMapManager.maxShortConnections < 1)
				{
					universeMapManager.maxShortConnections = 1;
				}
			}
		}
		else if (Input.GetKey(KeyCode.L))
		{
			if (!Input.GetKey(KeyCode.R))
			{
				if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
				{
					universeMapManager.maxLongConnections++;
					if (universeMapManager.maxLongConnections > 15)
					{
						universeMapManager.maxLongConnections = 15;
					}
				}
				else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
				{
					universeMapManager.maxLongConnections--;
					if (universeMapManager.maxLongConnections < 0)
					{
						universeMapManager.maxLongConnections = 0;
					}
				}
			}
			else if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
			{
				universeMapManager.reduceLongConnectionsFactor++;
				if (universeMapManager.reduceLongConnectionsFactor > 20)
				{
					universeMapManager.reduceLongConnectionsFactor = 20;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				universeMapManager.reduceLongConnectionsFactor--;
				if (universeMapManager.reduceLongConnectionsFactor < 0)
				{
					universeMapManager.reduceLongConnectionsFactor = 0;
				}
			}
		}
		else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.C))
		{
			if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
			{
				universeMapManager.BreakDownDepth++;
				if (universeMapManager.BreakDownDepth > 15)
				{
					universeMapManager.BreakDownDepth = 15;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				universeMapManager.BreakDownDepth--;
				if (universeMapManager.BreakDownDepth < 0)
				{
					universeMapManager.BreakDownDepth = 0;
				}
			}
		}
		else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.C))
		{
			if (Input.GetKeyDown(KeyCode.Plus) || Input.GetKeyDown(KeyCode.KeypadPlus) || Input.GetKeyDown(KeyCode.Equals))
			{
				universeMapManager.BreakDownChanceOf++;
				if (universeMapManager.BreakDownChanceOf > 15)
				{
					universeMapManager.BreakDownChanceOf = 15;
				}
			}
			else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
			{
				universeMapManager.BreakDownChanceOf--;
				if (universeMapManager.BreakDownChanceOf < 1)
				{
					universeMapManager.BreakDownChanceOf = 1;
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.C) && !Input.GetKey(KeyCode.D))
		{
			universeMapManager.CenterCamera();
		}
		if (Input.GetKeyDown(KeyCode.R) && !Input.GetKey(KeyCode.L))
		{
			universeMapManager.Clear();
			isStepingThroughNodeBuilding = true;
			GenerateUniverseNodes();
		}
		else if (Input.GetKeyDown(KeyCode.H))
		{
			isHelpHidden = !isHelpHidden;
		}
	}

	private void OnGUI()
	{
		if (isHelpHidden)
		{
			return;
		}
		Rect position = new Rect(0f, 0f, 400f, 30f);
		GUI.Label(position, "R: Re-generate the nodes", helpGuiStyle);
		position.y += 15f;
		GUI.Label(position, "H: Hide/Show Help", helpGuiStyle);
		if (isStepingThroughNodeBuilding)
		{
			position.y += 15f;
			GUI.Label(position, string.Format("SPACE: Build Next Layer of Nodes. {0} of {1}", universeMapManager.CountPlacedNodes, universeMapManager.NumberOfGalaxyNodes), helpGuiStyle);
			position.y += 15f;
			if (enableStepThroughCameraCentering)
			{
				GUI.Label(position, string.Format("C: Disable automatic camera centering."), helpGuiStyle);
			}
			else
			{
				GUI.Label(position, string.Format("C: Enable automatic camera centering."), helpGuiStyle);
			}
			position.y += 15f;
			GUI.Label(position, string.Format("X: Complete node build out (stop stepping through)"), helpGuiStyle);
			Rect position2 = new Rect(Screen.width - 300, 0f, 300f, 15f);
			GUI.Label(position2, string.Format("Max Number of Nodes: {0}", universeMapManager.NumberOfGalaxyNodes), helpGuiStyle);
			position2.y += 15f;
			GUI.Label(position2, string.Format("BiasFactor: {0}", universeMapManager.biasFactor), helpGuiStyle);
			position2.y += 15f;
			GUI.Label(position2, string.Format("Max Number of Short Connections per Node: {0}", universeMapManager.maxShortConnections), helpGuiStyle);
			position2.y += 15f;
			GUI.Label(position2, string.Format("Max Number of Long Connections per Node: {0}", universeMapManager.maxLongConnections), helpGuiStyle);
			position2.y += 15f;
			GUI.Label(position2, string.Format("Long Connections Reduction Factor (1 in x): {0}", universeMapManager.reduceLongConnectionsFactor), helpGuiStyle);
			position2.y += 25f;
			GUI.Label(position2, string.Format("Break Down Depth (depth branches begin to terminate): {0}", universeMapManager.BreakDownDepth), helpGuiStyle);
			position2.y += 15f;
			GUI.Label(position2, string.Format("Break Down Chance Of (1 in x): {0}", universeMapManager.BreakDownChanceOf), helpGuiStyle);
			position2.y += 15f;
			GUI.Label(position2, string.Format("* cannot change these settings while stepping through."), helpGuiStyle);
		}
		else
		{
			position.y += 15f;
			GUI.Label(position, "C: Center Camera", helpGuiStyle);
			Rect position3 = new Rect(Screen.width - 300, 0f, 300f, 15f);
			GUI.Label(position3, string.Format("N, +/-: Max Number of Nodes: {0}", universeMapManager.NumberOfGalaxyNodes), helpGuiStyle);
			position3.y += 15f;
			GUI.Label(position3, string.Format("B, +/-: BiasFactor: {0}", universeMapManager.biasFactor), helpGuiStyle);
			position3.y += 15f;
			GUI.Label(position3, string.Format("S, +/-: Max Number of Short Connections per Node: {0}", universeMapManager.maxShortConnections), helpGuiStyle);
			position3.y += 15f;
			GUI.Label(position3, string.Format("L, +/-: Max Number of Long Connections per Node: {0}", universeMapManager.maxLongConnections), helpGuiStyle);
			position3.y += 15f;
			GUI.Label(position3, string.Format("L+R, +/-: Long Connections Reduction Factor (1 in x): {0}", universeMapManager.reduceLongConnectionsFactor), helpGuiStyle);
			position3.y += 25f;
			GUI.Label(position3, string.Format("D, +/-: Break Down Depth (depth branches begin to terminate): {0}", universeMapManager.BreakDownDepth), helpGuiStyle);
			position3.y += 15f;
			GUI.Label(position3, string.Format("D+C, +/-: Break Down Chance Of (1 in x): {0}", universeMapManager.BreakDownChanceOf), helpGuiStyle);
			position3.y += 15f;
			GUI.Label(position3, string.Format("Re-generate the nodes for any changes to take effect"), helpGuiStyle);
		}
	}

	private void GenerateUniverseNodes()
	{
		NameGenerator.ShuffleGalaxyNames();
		universeMapManager.BuildListOfUniverseNodes();
		universeMapManager.BuildFirstLayer(-1000f);
		if (!isStepingThroughNodeBuilding)
		{
			universeMapManager.BuildAllRemainingLayers();
		}
		else
		{
			universeMapManager.BuildNextLayer();
		}
		universeMapManager.EnableAllEdges();
		universeMapManager.CenterCamera();
	}
}
