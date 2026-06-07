using System.Collections;
using UnityEngine;

public class OVRRuntimeController : MonoBehaviour
{
	public OVRInput.Controller m_controller;

	public Shader m_controllerModelShader;

	private GameObject m_controllerObject;

	private static string leftControllerModelPath = "/model_fb/controller/left";

	private static string rightControllerModelPath = "/model_fb/controller/right";

	private string m_controllerModelPath;

	private bool m_modelSupported;

	private bool m_hasInputFocus = true;

	private bool m_hasInputFocusPrev;

	private bool m_controllerConnectedPrev;

	private void Start()
	{
		if (m_controller == OVRInput.Controller.LTouch)
		{
			m_controllerModelPath = leftControllerModelPath;
		}
		else if (m_controller == OVRInput.Controller.RTouch)
		{
			m_controllerModelPath = rightControllerModelPath;
		}
		m_modelSupported = IsModelSupported(m_controllerModelPath);
		if (m_modelSupported)
		{
			StartCoroutine(UpdateControllerModel());
		}
		OVRManager.InputFocusAcquired += InputFocusAquired;
		OVRManager.InputFocusLost += InputFocusLost;
	}

	private void OnDestroy()
	{
		OVRManager.InputFocusAcquired -= InputFocusAquired;
		OVRManager.InputFocusLost -= InputFocusLost;
	}

	private void Update()
	{
		bool flag = OVRInput.IsControllerConnected(m_controller);
		if (m_hasInputFocus != m_hasInputFocusPrev || flag != m_controllerConnectedPrev)
		{
			if (m_controllerObject != null)
			{
				m_controllerObject.SetActive(flag && m_hasInputFocus);
			}
			m_hasInputFocusPrev = m_hasInputFocus;
			m_controllerConnectedPrev = flag;
		}
	}

	private bool IsModelSupported(string modelPath)
	{
		string[] renderModelPaths = OVRPlugin.GetRenderModelPaths();
		if (renderModelPaths.Length == 0)
		{
			Debug.LogError("Failed to enumerate model paths from the runtime. Check that the render model feature is enabled in OVRManager.");
			return false;
		}
		for (int i = 0; i < renderModelPaths.Length; i++)
		{
			if (renderModelPaths[i].Equals(modelPath))
			{
				return true;
			}
		}
		Debug.LogError("Render model path not supported by this device.");
		return false;
	}

	private bool LoadControllerModel(string modelPath)
	{
		OVRPlugin.RenderModelProperties modelProperties = default(OVRPlugin.RenderModelProperties);
		if (OVRPlugin.GetRenderModelProperties(modelPath, ref modelProperties))
		{
			if (modelProperties.ModelKey != 0L)
			{
				byte[] array = OVRPlugin.LoadRenderModel(modelProperties.ModelKey);
				if (array != null)
				{
					OVRGLTFLoader oVRGLTFLoader = new OVRGLTFLoader(array);
					oVRGLTFLoader.SetModelShader(m_controllerModelShader);
					m_controllerObject = oVRGLTFLoader.LoadGLB().root;
					if (m_controllerObject != null)
					{
						m_controllerObject.transform.SetParent(base.transform, worldPositionStays: false);
						m_controllerObject.transform.parent.localPosition = new Vector3(0f, -0.03f, -0.04f);
						m_controllerObject.transform.parent.localRotation = Quaternion.AngleAxis(-60f, new Vector3(1f, 0f, 0f));
						return true;
					}
				}
			}
			Debug.LogError("Retrived a null model key.");
		}
		Debug.LogError("Failed to load controller model");
		return false;
	}

	private IEnumerator UpdateControllerModel()
	{
		while (true)
		{
			bool flag = OVRInput.IsControllerConnected(m_controller);
			if (m_controllerObject == null && flag)
			{
				LoadControllerModel(m_controllerModelPath);
			}
			yield return new WaitForSeconds(0.5f);
		}
	}

	public void InputFocusAquired()
	{
		m_hasInputFocus = true;
	}

	public void InputFocusLost()
	{
		m_hasInputFocus = false;
	}
}
