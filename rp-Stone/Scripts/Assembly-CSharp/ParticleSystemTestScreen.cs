using UnityEngine;

public class ParticleSystemTestScreen : MonoBehaviour
{
	public enum State
	{
		Water = 0,
		Smoke = 1,
		Rain = 2,
		Fireworks = 3
	}

	public const float timePerTic = 0.03333333f;

	public State initialState;

	public AsciiRenderProcedural asciiRenderer;

	public AsciiParticleLayer particleLayer;

	public AsciiMouse mouseCursor;

	public DialogButton waterButton;

	public DialogButton smokeButton;

	public DialogButton rainButton;

	public DialogButton fireworksButton;

	public GameObject waterEmitters;

	public GameObject smokeEmitters;

	public GameObject rainEmitters;

	public GameObject fireworksEmitters;

	private State currentState;

	private float accumulatedTicTime;

	private void ChangeState(State newState)
	{
		EnableButton(waterButton, newState != State.Water);
		EnableButton(smokeButton, newState != State.Smoke);
		EnableButton(rainButton, newState != State.Rain);
		EnableButton(fireworksButton, newState != State.Fireworks);
		if (waterEmitters != null)
		{
			waterEmitters.SetActive(newState == State.Water);
		}
		if (smokeEmitters != null)
		{
			smokeEmitters.SetActive(newState == State.Smoke);
		}
		if (rainEmitters != null)
		{
			rainEmitters.SetActive(newState == State.Rain);
		}
		if (fireworksEmitters != null)
		{
			fireworksEmitters.SetActive(newState == State.Fireworks);
		}
		currentState = newState;
	}

	private void EnableButton(DialogButton button, bool enable)
	{
		if (enable)
		{
			button.label.color = Color.gray;
			button.edgeSymbols.color = Color.gray;
			button.HasFocus = true;
		}
		else
		{
			button.label.color = Color.white;
			button.edgeSymbols.color = Color.black;
			button.HasFocus = false;
		}
	}

	private void Update()
	{
		UpdateTics(Utils.deltaTime);
		Draw();
	}

	private void UpdateTics(float deltaTime)
	{
		accumulatedTicTime += deltaTime;
		while (accumulatedTicTime >= 0.03333333f)
		{
			accumulatedTicTime -= 0.03333333f;
			UpdateTic();
		}
	}

	private void UpdateTic()
	{
		particleLayer.UpdateTic();
		mouseCursor.UpdateTic();
		waterButton.UpdateTic();
		smokeButton.UpdateTic();
		rainButton.UpdateTic();
		fireworksButton.UpdateTic();
	}

	private void Draw()
	{
		AsciiRenderProcedural asciiRenderProcedural = asciiRenderer;
		asciiRenderProcedural.Clear();
		waterButton.Draw(asciiRenderProcedural, 0, 0);
		smokeButton.Draw(asciiRenderProcedural, 0, 0);
		rainButton.Draw(asciiRenderProcedural, 0, 0);
		fireworksButton.Draw(asciiRenderProcedural, 0, 0);
		particleLayer.Draw(asciiRenderProcedural, 0, 0);
		mouseCursor.Draw(asciiRenderProcedural, 0, 0);
		DrawLightning(asciiRenderProcedural);
		asciiRenderProcedural.Push();
	}

	private void DrawLightning(AsciiRenderProcedural r)
	{
		if (currentState != State.Rain || !Input.GetMouseButton(0))
		{
			return;
		}
		for (int i = 0; i < r.width; i++)
		{
			for (int j = 0; j < r.height; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				Color background = cell.GetBackground();
				Color foreground = cell.GetForeground();
				background = Color.white - background;
				foreground = Color.white - foreground;
				cell.SetBackground(background);
				cell.SetForeground(foreground);
			}
		}
	}

	private void Start()
	{
		ChangeState(initialState);
		waterButton.OnPressed += WaterButtonOnPressed;
		smokeButton.OnPressed += SmokeButtonOnPressed;
		rainButton.OnPressed += RainButtonOnPressed;
		fireworksButton.OnPressed += FireworksButtonOnPressed;
	}

	private void WaterButtonOnPressed(DialogButton button)
	{
		ChangeState(State.Water);
	}

	private void SmokeButtonOnPressed(DialogButton button)
	{
		ChangeState(State.Smoke);
	}

	private void RainButtonOnPressed(DialogButton button)
	{
		ChangeState(State.Rain);
	}

	private void FireworksButtonOnPressed(DialogButton button)
	{
		ChangeState(State.Fireworks);
	}
}
