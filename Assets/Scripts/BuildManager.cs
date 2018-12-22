using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject standardTurretPrefab;

    private GameObject turretToBuild;

    private void Awake() {
        if (instance != null) {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    // Use this for initialization
    void Start () {
        turretToBuild = standardTurretPrefab;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public GameObject GetTurretToBuild() {
        return turretToBuild;
    }
}
