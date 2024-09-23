using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent onScored;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            onScored.Invoke(eventData);
        }
    }
}
