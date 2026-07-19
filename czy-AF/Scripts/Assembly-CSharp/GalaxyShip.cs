using UnityEngine;

public class GalaxyShip : MonoBehaviour
{
	private float speed = 30f;

	private Vector3 shipTarget;

	private Vector3 shipRotation;

	private Switch crosshair;

	private Vector3 crosshairStart;

	private float shootCooldown;

	private void Awake()
	{
		crosshair = GalaxyGame.elements["crosshair"].GetComponent<Switch>();
		crosshairStart = GalaxyGame.elements["crosshair"].position;
	}

	private void Update()
	{
		if (Input.GetKey("a"))
		{
			shipTarget.y -= 1.25f;
			shipTarget.z = 60f;
		}
		else if (Input.GetKey("d"))
		{
			shipTarget.y += 1.25f;
			shipTarget.z = -60f;
		}
		else
		{
			shipTarget.z = 0f;
		}
		if (Input.GetKey("w"))
		{
			shipTarget.x += 0.75f;
		}
		else if (Input.GetKey("s"))
		{
			shipTarget.x -= 0.75f;
		}
		base.transform.Translate(Vector3.forward * speed * Time.deltaTime);
		shipTarget.x = Mathf.Clamp(shipTarget.x, -80f, 80f);
		shipRotation = Vector3.Lerp(shipRotation, shipTarget, Time.deltaTime * 3f);
		base.transform.rotation = Quaternion.Euler(shipRotation);
		if (GalaxyGame.distance < 100)
		{
			speed = GalaxyGame.distance;
			speed = Mathf.Clamp(speed, 5f, 60f);
		}
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 b = crosshairStart;
		if (Physics.SphereCast(ray, 20f, out var hitInfo))
		{
			if ((bool)hitInfo.transform.GetComponent<GalaxyEnemy>())
			{
				crosshair.SetSprite(1);
				b = Camera.main.WorldToScreenPoint(hitInfo.transform.position);
				if (Input.GetMouseButton(0) && shootCooldown <= 0f)
				{
					GalaxyGame.Bullet(GalaxyGame.weapons[Random.Range(0, GalaxyGame.weapons.Count)].position, hitInfo.transform.position);
					shootCooldown = 0.1f;
				}
			}
			else
			{
				crosshair.SetSprite(0);
			}
		}
		else
		{
			crosshair.SetSprite(0);
		}
		GalaxyGame.elements["crosshair"].position = Vector3.Lerp(GalaxyGame.elements["crosshair"].position, b, 20f * Time.deltaTime);
		if (shootCooldown > 0f)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
}
