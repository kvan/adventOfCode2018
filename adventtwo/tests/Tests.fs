module Tests

open System
open Xunit
open AdventTwo

[<Fact>]
let ``hasNumber finds something`` () =
    Assert.Equal(Some 'a', ProblemOne.hasNumber "aab" 2)
    Assert.Equal(Some 'b', ProblemOne.hasNumber "aabbb" 3)
    Assert.Equal(Some 'a', ProblemOne.hasNumber "aabb" 2)

[<Fact>]
let ``hasNumber finds nothing`` () =
    Assert.Equal(None, ProblemOne.hasNumber "abc" 2)

[<Fact>]
let ``checksum`` () =
    let boxes = [| "abcdef"; "bababc"; "abbcde"; "abcccd"; "aabcdd"; "abcdee"; "ababab" |]
    Assert.Equal(12, ProblemOne.checksum boxes)

[<Fact>]
let ``commonletters`` () =
    Assert.Equal("abc", ProblemTwo.commonLetters "abcf" "abcd")
    Assert.Equal("", ProblemTwo.commonLetters "abc" "def")
    Assert.Equal("f", ProblemTwo.commonLetters "abcf" "cdef")
    Assert.Equal("aksjdhfbv", ProblemTwo.commonLetters "aksjqdhfbv" "aksjydhfbv")
