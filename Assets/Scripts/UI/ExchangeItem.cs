using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ExchangeItem : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TMP_Text _itemNameText;
    [SerializeField] private TMP_Text _itemCountText;
    [SerializeField] private TMP_Text _itemPriceText;

    [SerializeField] private Image _avatarImage;
    [SerializeField] private TMP_Text _playerNameText;
    [SerializeField] private TMP_Text _playerLevelText;

    public void UpdateUI(ExchangeItemData data)
    {
        _itemImage.sprite = Resources.Load<Sprite>($"Sprites/{data.ItemImageName}");
        _itemNameText.text = data.ItemName;
        _itemCountText.text = $"x{data.ItemCount}";
        _itemPriceText.text = data.ItemPrice.ToString();

        StartCoroutine(DownloadImage(data.PlayerImageId));
        _playerNameText.text = data.PlayerName;
        _playerLevelText.text = data.PlayerLevel.ToString();
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    private IEnumerator DownloadImage(int imageId)
    {
        var size = 85;
        var request = UnityWebRequestTexture.GetTexture($"https://picsum.photos/id/{imageId}/{85}/{85}");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, size, size), new Vector2(0, 0));
            _avatarImage.sprite = sprite;
        }
    }
}
