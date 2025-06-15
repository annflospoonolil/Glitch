using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class Scoring : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTriggger;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTriggger.Invoke(eventData);
        }
    }
    }
