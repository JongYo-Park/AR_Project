using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GunShoot : MonoBehaviour {

    [SerializeField] float fireRate = 0.25f;
    [SerializeField] float weaponRange = 20f;

    [SerializeField] int score = 1;
    private ScoreManager scoreManager;

    [SerializeField] Transform gunEnd;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem cartridgeEjection;


    [SerializeField] float nextFire;
    [SerializeField] Animator animator;

    [SerializeField] AudioClip fireSfx;
    private AudioSource source;

    
    

    void Start () 
	{
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator> ();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

	void Update () 
	{
		if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			muzzleFlash.Play();
			cartridgeEjection.Play();
			animator.SetTrigger("Fire");
            source.PlayOneShot(fireSfx, 0.9f);

            Vector3 rayOrigin = gunEnd.position;
			RaycastHit hit;

			if (Physics.Raycast(rayOrigin, gunEnd.forward, out hit, weaponRange))
            {
				if (hit.collider.CompareTag("Monster"))
				{
                    Debug.Log($"코인 획득, 점수 {score} 획득");
                    if (scoreManager != null)
                    {
                        scoreManager.AddScore(score);
                    }
                    Destroy(hit.collider.gameObject);
				}
			}
		}
	}

	

	void SpawnDecal(RaycastHit hit, GameObject prefab)
	{
		GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
		spawnedDecal.transform.SetParent(hit.collider.transform);
	}
}