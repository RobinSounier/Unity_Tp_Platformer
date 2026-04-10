using UnityEngine;

namespace Assets.Script.Level1
{
    public class KeySysteme : MonoBehaviour
    {
        public GameObject keyObject;
        private int collectibleCount;
        private bool keyActivated = false; // ← évite l'appel répété chaque frame

        void Start()
        {
            keyObject.SetActive(false);
            collectibleCount = GameObject.FindGameObjectsWithTag("Collectible").Length;
        }

        void Update()
        {
            if (collectibleCount <= 0 && !keyActivated)
            {
                if (keyObject != null) // ← garde contre la destruction accidentelle
                {
                    keyObject.SetActive(true);
                    keyActivated = true;
                }
                else
                {
                    Debug.LogError("keyObject est null ou détruit !");
                }
            }
        }

        public void OnCollectibleDestroyed()
        {
            collectibleCount--;
        }
    }
}