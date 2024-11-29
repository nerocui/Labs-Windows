// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CommunityToolkit.Labs.WinUI.MarkdownTextBlock;

namespace MarkdownTextBlockExperiment.Samples;
/// <summary>
/// An example sample page of a custom control inheriting from Panel.
/// </summary>
[ToolkitSample(id: nameof(StreamingSamplePage), "Custom control", description: $"A sample for showing how to create and use a {nameof(CommunityToolkit.Labs.WinUI.MarkdownTextBlock)} custom control.")]
public sealed partial class StreamingSamplePage : Page
{
    public ObservableCollection<Message> Messages { get; } = new ObservableCollection<Message>();
    private MarkdownConfig _config = new MarkdownConfig();
    public StreamingSamplePage()
    {
        this.InitializeComponent();
    }

    private async void TextBox_KeyUp(object sender, KeyRoutedEventArgs e)
    {

    }

    public async Task SendMessage(TextBox textBox)
    {
        if (!string.IsNullOrWhiteSpace(textBox.Text))
        {
            Messages.Add(new Message(ComposeBox.Text, HorizontalAlignment.Right, _config));
            ComposeBox.Text = string.Empty;

            //await CompleteChat();
        }
    }

    //private IAsyncEnumerable<string> StreamExample(string markdown)
    //{
    //    for (int i = 0; i < markdown.Length;)
    //    {
    //        int nextWord = NextWord(markdown, i);
    //        yield return markdown[i..nextWord];
    //        i += nextWord;
    //        await Task.Delay(100);
    //    }
    //}
}

public class Message
{
    public string Text { get; set; }
    public HorizontalAlignment HorizontalAlignment { get; set; }
    public MarkdownConfig Config { get; private set; }

    public Message(string text, HorizontalAlignment horizontalAlignment, MarkdownConfig config)
    {
        Text = text;
        HorizontalAlignment = horizontalAlignment;
        Config = config;
    }
}
