defmodule AdventOne do
  def main(args) do
    case File.read(hd(args)) do
      {:ok, body} -> body
      |> String.split("\n", trim: true)
      |> sum_list
      |> IO.inspect
      {:error, _} -> IO.puts "Non merci!\n"
    end
  end

  def sum_list([]) do
    0
  end

  def sum_list([h|t]) do
    {val, ""} = Integer.parse(h)
    val + sum_list(t)
  end
end
